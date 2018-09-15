using System;
using AcceleratedTool.XmlApi.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class BooleanExtentionTests
    {
        [Test]
        public void TestThatBoolStringIsConvertedToBoolCorrectly()
        {
            var data = "true";
            var result = data.ToApiBoolFormat();
            Assert.AreEqual(true, result);

            data = "false";
            result = data.ToApiBoolFormat();
            Assert.AreEqual(false, result);

            data = "TRUE";
            result = data.ToApiBoolFormat();
            Assert.AreEqual(true, result);

            data = "FALSE";
            result = data.ToApiBoolFormat();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestThatBoolIsConvertedToStringCorrectly()
        {
            var data = true;
            var result = data.ToApiBoolFormat();
            Assert.AreEqual("true", result);

            var dataNullable1 = (bool?)true;
            Assert.AreEqual("true", dataNullable1.ToApiBoolFormat());

            var dataNullable2 = (bool?)null;
            Assert.AreEqual(string.Empty, dataNullable2.ToApiBoolFormat());
        }
    }
}
