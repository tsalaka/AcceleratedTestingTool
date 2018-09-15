using AcceleratedTool.ExcelDocument.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests.Extentions
{
    [TestFixture]
    public class BooleanExtentionTests
    {
        [Test]
        public void TestThatBoolStringIsConvertedToBoolCorrectly()
        {
            var data = "true";
            var result = data.ToBoolFormat();
            Assert.AreEqual(true, result);

            data = "false";
            result = data.ToBoolFormat();
            Assert.AreEqual(false, result);

            data = "TRUE";
            result = data.ToBoolFormat();
            Assert.AreEqual(true, result);

            data = "FALSE";
            result = data.ToBoolFormat();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestThatBoolIsConvertedToStringCorrectly()
        {
            var data = true;
            var result = data.ToBoolFormat();
            Assert.AreEqual("TRUE", result);

            data = false;
            result = data.ToBoolFormat();
            Assert.AreEqual("FALSE", result);
        }
    }
}
