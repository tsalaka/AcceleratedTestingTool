using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests
{
    [TestFixture]
    public class ExcelFileDataTests
    {
        [Test]
        public void TestThatExcelFileDataConstructorSetCorrectValuesOfExcelDataModel()
        {
            var exceldata = new ExcelData
            {
                Headers = new List<string>
                {
                    "Header1"
                },
                DataRows = new List<List<string>>
                {
                    new List<string> {"Data1"},
                    new List<string> {"Data2"}
                },
                SheetName = "Sheet"
            };

            var excelFileData = new ExcelFileData(exceldata);
            Assert.AreEqual(1, excelFileData.Headers.Count);
            Assert.AreEqual(2, excelFileData.DataRows.Count);
            Assert.AreEqual(1, excelFileData.DataRows[0].Count);
            Assert.AreEqual(1, excelFileData.DataRows[1].Count);
            Assert.AreEqual("Header1", excelFileData.Headers.First());
            Assert.AreEqual("Data1", excelFileData.DataRows[0].First());
            Assert.AreEqual("Data2", excelFileData.DataRows[1].First());
            Assert.AreEqual("Sheet", excelFileData.SheetName);
        }
    }
}
