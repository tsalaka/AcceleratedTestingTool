using System;
using System.Data;
using System.IO;
using System.Text;

namespace AcceleratedTool.ExcelDocument.Csv
{
    public class CsvWriter
    {
        public const string CellFormat = "{0},";
        private const int PortionNumber = 10000;

        public void SaveToCsv(ExcelFileData data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.FilePath))
                    throw new DataException("Excel file path is not provided");

                if (!data.UpdateExistingFile)
                    throw new NotSupportedException();

                if (data.Headers != null)
                {
                    // add headers to a file
                    var headers = new StringBuilder();
                    foreach (var header in data.Headers)
                    {
                        headers.Append(string.Format(CellFormat, header));
                    }

                    using (var w = new StreamWriter(data.FilePath, false))
                    {
                        w.WriteLine(headers);
                        w.Flush();
                    }
                }

                if (data.DataRows != null)
                {
                    // add rows by portions in PortionNumber rows to a file
                    var dataContent = new StringBuilder();
                    for (int i = 0; i < data.DataRows.Count; i++)
                    {
                        var isLastRowInPortion = (i + 1) % PortionNumber == 0 || i == data.DataRows.Count - 1;
                        for (int j = 0; j < data.DataRows[i].Count; j++)
                        {
                            var cellData = data.DataRows[i][j];
                            if (cellData.IndexOf(',') > 0)
                            {
                                cellData = string.Format("\"{0}\"", cellData);
                            }

                            if (!isLastRowInPortion && j == data.DataRows[i].Count - 1)
                                dataContent.AppendLine(string.Format(CellFormat, cellData));
                            else
                                dataContent.Append(string.Format(CellFormat, cellData));
                        }

                        if (isLastRowInPortion)
                        {
                            using (var w = new StreamWriter(data.FilePath, true))
                            {
                                w.WriteLine(dataContent);
                                w.Flush();
                                dataContent = dataContent.Clear();
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException("An exception occurs during Excel data writing", ex);
            }
        }
    }
}
