using System;
using System.Collections.Generic;
using System.IO;
using AcceleratedTool.ExcelDocument.Csv;
using AcceleratedTool.ExcelDocument.OpenXml;

namespace AcceleratedTool.ExcelDocument
{
    public class ExcelDataComponent<TEntity>
        where TEntity : class
    {
        private readonly ExcelWriter _writer;
        private readonly CsvWriter _csvWriter;
        private readonly ExcelReader _reader;
        private readonly ExcelDataMapper<TEntity> _mapper;

        public ExcelDataComponent(ExcelWriter writer, ExcelDataMapper<TEntity> mapper, ExcelReader reader, CsvWriter csvWriter)
        {
            _writer = writer;
            _mapper = mapper;
            _reader = reader;
            _csvWriter = csvWriter;
        }

        public void ConvertToExcel(List<TEntity> entities, string filePath, string sheetName, bool updateExistingFile = false)
        {
            var data = _mapper.Map(entities, sheetName);
            if (data == null)
                throw new Exception(string.Format("{0} cannot be convert to '{1}' excel file", typeof(TEntity), filePath));

            var fileData = new ExcelFileData(data)
            {
                FilePath = filePath,
                UpdateExistingFile = updateExistingFile
            };

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                CreateDirectoryRecursively(filePath);

            _writer.SaveToExcel(fileData);
        }

        /// <summary>
        /// Convert data from excel sheet to list of enitites
        /// </summary>
        /// <param name="filePath">physical path to save an excel file</param>
        /// <param name="entities">Data to convert</param>
        /// <returns></returns>
        public void ConvertToCsv(List<TEntity> entities, string filePath)
        {
            var data = _mapper.Map(entities, null);
            if (data == null)
                throw new Exception(string.Format("{0} cannot be convert to '{1}' excel file", typeof(TEntity), filePath));
            var fileData = new ExcelFileData(data)
            {
                FilePath = filePath,
                UpdateExistingFile = true
            };

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                CreateDirectoryRecursively(filePath);

            _csvWriter.SaveToCsv(fileData);
        }

        /// <summary>
        /// Convert data from excel sheet to list of enitites
        /// </summary>
        /// <param name="filePath">physical path to save an excel file</param>
        /// <param name="sheetName">Sheet Name for data reading</param>
        /// <returns></returns>
        public List<TEntity> ReadFromExcelSheet(string filePath, string sheetName)
        {
            var excelData = _reader.ReadExcel(filePath, sheetName);
            var entities = _mapper.Map(excelData);

            return entities;
        }

        private bool CreateDirectoryRecursively(string path)
        {
            try
            {
                string[] pathParts = path.Split('\\');
                for (var i = 0; i < pathParts.Length; i++)
                {
                    // Correct part for drive letters
                    if (i == 0 && pathParts[i].Contains(":"))
                    {
                        pathParts[i] = pathParts[i] + "\\";
                    } // Do not try to create last part if it has a period (is probably the file name)
                    else if (i == pathParts.Length - 1 && pathParts[i].Contains("."))
                    {
                        return true;
                    }

                    if (i > 0)
                    {
                        pathParts[i] = Path.Combine(pathParts[i - 1], pathParts[i]);
                    }

                    if (!Directory.Exists(pathParts[i]))
                    {
                        Directory.CreateDirectory(pathParts[i]);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occurs during directory creation", ex);
            }
        }
    }
}
