using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AcceleratedTool.Excel.Models.Attributes;
using AcceleratedTool.ExcelDocument.Exceptions;

namespace AcceleratedTool.ExcelDocument
{
    public class ExcelDataMapper<TEntity>
    {
        private readonly IExcelDataFormatConvertor _excelDataFormatConvertor;

        public ExcelDataMapper(IExcelDataFormatConvertor excelDataFormatConvertor)
        {
            _excelDataFormatConvertor = excelDataFormatConvertor;
        }

        public ExcelData Map(List<TEntity> entities, string sheetName)
        {
            try
            {
                ExcelData data = new ExcelData();
                data.SheetName = sheetName;
                data.Headers = new List<string>();
                data.DataRows = new List<List<string>>();
                PropertyInfo[] properties;
                try
                {
                    properties = typeof(TEntity)
                        .GetProperties()
                        .OrderBy(p => p.GetCustomAttributes().OfType<ExcelColumnAttribute>().First().Order)
                        .Select(p => p).ToArray();
                }
                catch (InvalidOperationException)
                {
                    throw new Exception(string.Format("{0} Data can't be import to Excel. Please check than ExcelColumn attribute is specified for each columns", typeof(TEntity)));
                }

                if (entities == null || !entities.Any())
                {
                    data.Headers.AddRange(GetHeaders(properties));
                    return data;
                }

                var propertiesFormat = new Dictionary<string, string>();
                for (int i = 0; i < entities.Count; i++)
                {
                    var rowCellsValues = new List<string>();
                    foreach (var property in properties)
                    {
                        // add headers based on entity properties names
                        if (i == 0)
                        {
                            var excelAttribute =
                                property.GetCustomAttributes().First(attr => attr is ExcelColumnAttribute) as
                                    ExcelColumnAttribute;
                            if (excelAttribute != null)
                            {
                                data.Headers.Add(!string.IsNullOrEmpty(excelAttribute.Name)
                                    ? excelAttribute.Name
                                    : property.Name);

                                if (excelAttribute.Format != ExcelColumnFormat.None)
                                {
                                    propertiesFormat.Add(property.Name, _excelDataFormatConvertor.GetFormatByFormatType(excelAttribute.Format));
                                }
                            }
                        }

                        object propertyValue = property.GetValue(entities[i], null);
                        string customFormat = propertiesFormat.ContainsKey(property.Name) ? propertiesFormat[property.Name] : null;
                        var cellValue = _excelDataFormatConvertor.ConvertValueToString(propertyValue, customFormat);
                        rowCellsValues.Add(cellValue);
                    }

                    data.DataRows.Add(rowCellsValues);
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occurs during Excel data writing", ex);
            }
        }

        public List<TEntity> Map(ExcelData data)
        {
            try
            {
                if (data == null)
                    return null;

                PropertyInfo[] properties;
                try
                {
                    properties = typeof(TEntity)
                        .GetProperties()
                        .OrderBy(p => p.GetCustomAttributes().OfType<ExcelColumnAttribute>().First().Order)
                        .Select(p => p).ToArray();
                }
                catch (InvalidOperationException)
                {
                    throw new Exception(
                        string.Format("{0} Data can't be import to Excel. Please check than ExcelColumn attribute is specified for each columns",
                            typeof(TEntity)));
                }

                if (!data.DataRows.Any())
                    return new List<TEntity>();

                var entities = new List<TEntity>();

                var excelColumnProperties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
                var excelColumnAttributes =
                    new Dictionary<string, ExcelColumnAttribute>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < data.DataRows.Count; i++)
                {
                    var row = data.DataRows[i];

                    // skip a row if all cells are empty
                    if (row.All(string.IsNullOrEmpty))
                        continue;

                    var entity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] {});

                    for (int j = 0; j < data.Headers.Count; j++)
                    {
                        if (i == 0 && !string.IsNullOrEmpty(data.Headers[j]))
                        {
                            ExcelColumnAttribute excelColumnAttribute = null;
                            var excelColumnProperty = properties
                                .FirstOrDefault(p =>
                                {
                                    if (p.CanWrite &&
                                        p.Name.Equals(data.Headers[j], StringComparison.CurrentCultureIgnoreCase))
                                        return true;
                                    var item = p.GetCustomAttributes()
                                        .OfType<ExcelColumnAttribute>()
                                        .FirstOrDefault();
                                    if (item != null && item.Name != null)
                                    {
                                        if (item.Name.Equals(data.Headers[j], StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            excelColumnAttribute = item;
                                            return true;
                                        }
                                    }
                                    return false;
                                });

                            if (excelColumnProperty != null)
                            {
                                if (excelColumnProperties.ContainsKey(data.Headers[j]))
                                    throw new InvalidDataException(string.Format("Input excel contains more than one columns with '{0}' name", data.Headers[j]));

                                excelColumnProperties.Add(data.Headers[j], excelColumnProperty);
                            }

                            if (excelColumnAttribute != null)
                            {
                                excelColumnAttributes.Add(data.Headers[j], excelColumnAttribute);
                            }
                        }

                        if (j >= row.Count)
                            continue;
                        var cell = row[j];

                        // don't write values of a column if a header is empty
                        if (!excelColumnProperties.ContainsKey(data.Headers[j]))
                            continue;
                        var property = excelColumnProperties[data.Headers[j]];
                        ExcelColumnAttribute excelAttribute;
                        excelColumnAttributes.TryGetValue(data.Headers[j], out excelAttribute);
                        Type propertyType = property.PropertyType;
                        object propertyValue;
                        try
                        {
                            propertyValue = _excelDataFormatConvertor.ConvertStringToValue(cell, propertyType, excelAttribute?.Format ?? ExcelColumnFormat.None);
                            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            object safeValue = (propertyValue == null) ? null : Convert.ChangeType(propertyValue, t);
                            property.SetValue(entity, safeValue, null);
                        }
                        catch (Exception ex) when (ex is InvalidCastException || ex is FormatException)
                        {
                            var columnName = data.Headers[j];
                            var rowNumber = i + 2;
                            throw new InvalidFormatOfExcelCellException(data.SheetName, columnName, rowNumber, ex);
                        }
                    }

                    entities.Add(entity);
                }

                return entities;
            }
            catch (InvalidFormatOfExcelCellException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occurs during Excel data reading", ex);
            }
        }

        private List<string> GetHeaders(PropertyInfo[] properties)
        {
            var data = new List<string>();
            foreach (var property in properties)
            {
                var excelAttribute = property.GetCustomAttributes().First(attr => attr is ExcelColumnAttribute) as ExcelColumnAttribute;
                if (excelAttribute != null && !string.IsNullOrEmpty(excelAttribute.Name))
                    data.Add(excelAttribute.Name);
                else
                    data.Add(property.Name);
            }

            return data;
        }
    }
}
