using System;
using AcceleratedTool.ExcelDocument.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests.Extentions
{
    [TestFixture]
    public class DateTimeExtentionTests
    {
        [Test]
        public void TestThatDateStringIsConvertedCorrectly()
        {
            var date = "12/29/2017";
            var result = date.ToDateFormat();
            Assert.AreEqual(new DateTime(2017, 12, 29), result);

            date = "10/9/2017";
            result = date.ToDateFormat();
            Assert.AreEqual(new DateTime(2017, 10, 9), result);
        }

        [Test]
        public void TestThatDoubleDateStringIsConvertedCorrectly()
        {
            var date = "35834"; // 2/8/1998
            var result = date.ToDateFormat();
            Assert.AreEqual(new DateTime(1998, 2, 8), result);

            date = "36264"; // 4/14/1999
            result = date.ToDateFormat();
            Assert.AreEqual(new DateTime(1999, 4, 14), result);
        }

        [Test]
        public void TestThatDateIsConvertedToStringCorrectly()
        {
            var date = new DateTime(2017, 3, 1);
            var result = date.ToDateFormat();
            Assert.AreEqual("3/1/2017", result);
        }

        [Test]
        public void TestThatDateWithTimeIsConvertedToStringCorrectly()
        {
            var date = new DateTime(2017, 3, 1, 13, 45, 34);
            var result = date.ToDateFormat("M/d/yyyy H:mm:ss");
            Assert.AreEqual("3/1/2017 13:45:34", result);

            date = new DateTime(2017, 3, 1, 2, 13, 20);
            result = date.ToDateFormat("M/d/yyyy H:mm:ss");
            Assert.AreEqual("3/1/2017 2:13:20", result);
        }
    }
}
