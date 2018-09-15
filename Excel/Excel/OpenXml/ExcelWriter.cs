using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AcceleratedTool.ExcelDocument.OpenXml
{
    public class ExcelWriter
    {
        public void SaveToExcel(ExcelFileData data)
        {
            if (string.IsNullOrEmpty(data.FilePath))
                throw new ArgumentNullException("filePath");

            WorksheetPart workSheetPart;
            data.SheetName = data.SheetName ?? ExcelData.DefaultSheetName;
            if (data.UpdateExistingFile)
            {
                try
                {
                    using (SpreadsheetDocument document = SpreadsheetDocument.Open(data.FilePath, true))
                    {
                        workSheetPart = AddWorkSheet(data.SheetName, document.WorkbookPart, data.UpdateExistingFile);

                        PopulateData(data, workSheetPart);

                        document.WorkbookPart.Workbook.Save();
                    }
                }
                catch (OpenXmlPackageException)
                {
                    throw new FileNotFoundException("File is not found", data.FilePath);
                }
            }
            else
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(data.FilePath, SpreadsheetDocumentType.Workbook))
                {
                    var workBookPart = document.AddWorkbookPart();
                    workBookPart.Workbook = new Workbook();
                    workSheetPart = AddWorkSheet(data.SheetName, document.WorkbookPart, data.UpdateExistingFile);

                    PopulateData(data, workSheetPart);
                    workBookPart.Workbook.Save();
                }
            }
        }

        private static WorksheetPart AddWorkSheet(string sheetName, WorkbookPart workBookPart, bool updateExistingFile)
        {
            WorksheetPart workSheetPart = null;
            uint? sheetId = null;
            Sheet sheet = workBookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name.Value.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
            if (sheet == null)
            {
                workSheetPart = workBookPart.AddNewPart<WorksheetPart>();
                workSheetPart.Worksheet = new Worksheet(new SheetData());
                workSheetPart.Worksheet.Save();
            }
            else
            {
                workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id);
                sheetId = sheet.SheetId;
                sheet.Remove();
            }

            Sheets sheets = workBookPart.Workbook.GetFirstChild<Sheets>();
            if (!updateExistingFile)
                sheets = sheets ?? workBookPart.Workbook.AppendChild<Sheets>(new Sheets());

            string relationshipId = workBookPart.GetIdOfPart(workSheetPart);
            if (sheets.Elements<Sheet>().Count() > 0)
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }

            Sheet newSheet = new Sheet
            {
                Id = relationshipId,
                SheetId = sheetId ?? 1,
                Name = sheetName
            };
            sheets.Append(newSheet);

            return workSheetPart;
        }

        private void PopulateData(ExcelFileData data, WorksheetPart worksheetPart)
        {
            // Add header
            uint rowIdex = 0;
            var row = new Row { RowIndex = ++rowIdex };
            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            sheetData.AppendChild(row);
            var cellIdex = 0;

            foreach (var header in data.Headers)
            {
                row.AppendChild(CreateTextCell(ColumnLetter(cellIdex++), rowIdex, header ?? string.Empty));
            }

            if (data.Headers.Count > 0)
            {
                // Add the column configuration if available
                if (data.ColumnConfigurations != null)
                {
                    var columns = (Columns)data.ColumnConfigurations.Clone();
                    worksheetPart.Worksheet.InsertAfter(columns, worksheetPart.Worksheet.SheetFormatProperties);
                }
            }

            // Add sheet data
            foreach (var rowData in data.DataRows)
            {
                cellIdex = 0;
                row = new Row {RowIndex = ++rowIdex};
                sheetData.AppendChild(row);
                foreach (var cellData in rowData)
                {
                    var cell = CreateTextCell(ColumnLetter(cellIdex++),
                        rowIdex,
                        cellData ?? string.Empty);
                    row.AppendChild(cell);
                }
            }
        }

        private string ColumnLetter(int intCol)
        {
            var intFirstLetter = (intCol / 676) + 64;
            var intSecondLetter = ((intCol % 676) / 26) + 64;
            var intThirdLetter = (intCol % 26) + 65;

            var firstLetter = (intFirstLetter > 64)
                ? (char)intFirstLetter : ' ';
            var secondLetter = (intSecondLetter > 64)
                ? (char)intSecondLetter : ' ';
            var thirdLetter = (char)intThirdLetter;

            return string.Concat(firstLetter, secondLetter, thirdLetter).Trim();
        }

        private Cell CreateTextCell(string header, uint index, string text)
        {
            var cell = new Cell
            {
                CellReference = header + index,
            };

            // try to convert value to int to set up correct cell format
            // if text can be converted to int but starts from zeros, it will be pasted as string in order to save zeros
            int intValue;
            if (int.TryParse(text, out intValue) && text == intValue.ToString())
            {
                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                cell.CellValue = new CellValue(text);
            }
            else
            {
                cell.DataType = CellValues.InlineString;
                var istring = new InlineString();
                var t = new Text { Text = text };
                istring.AppendChild(t);
                cell.AppendChild(istring);
            }

            return cell;
        }
    }
}
