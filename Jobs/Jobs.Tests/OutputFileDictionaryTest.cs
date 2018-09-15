using Kronos.AcceleratedTool.Jobs;
using NUnit.Framework;
using System.Configuration;

namespace Jobs.Tests
{
    [TestFixture]
    public class OutputFileDictionaryTest
    {
        private readonly OutputFileDictionary _outputFileDictionary;

        public OutputFileDictionaryTest()
        {
            var outputDirectorySettings = new OutputDirectory
            {
                Path = ConfigurationManager.AppSettings["OutputDirectory"],
                ExcelFolder = ConfigurationManager.AppSettings["ExcelFolder"],
                SourceFolder = ConfigurationManager.AppSettings["SourceDirectory"],
                XmlFolder = ConfigurationManager.AppSettings["XmlDirectory"]
            };

            _outputFileDictionary = new OutputFileDictionary(outputDirectorySettings);
        }

        [Test]
        public void TimesheetSourcePunch()
        {
            var result = _outputFileDictionary.TimesheetSourcePunch;
            Assert.AreEqual(result.FilePath, @"..\SourceFile\TimesheetSource.xlsx");
            Assert.AreEqual(result.SheetName, @"Punch");
        }

        [Test]
        public void TimesheetSourceSchedule()
        {
            var result = _outputFileDictionary.TimesheetSourceSchedule;
            Assert.AreEqual(result.FilePath, @"..\SourceFile\TimesheetSource.xlsx");
            Assert.AreEqual(result.SheetName, @"Schedule");
        }

        [Test]
        public void TimesheetSourcePaycodeEdit()
        {
            var result = _outputFileDictionary.TimesheetSourcePaycodeEdit;
            Assert.AreEqual(result.FilePath, @"..\SourceFile\TimesheetSource.xlsx");
            Assert.AreEqual(result.SheetName, @"PaycodeEdit");
        }
    }
}
