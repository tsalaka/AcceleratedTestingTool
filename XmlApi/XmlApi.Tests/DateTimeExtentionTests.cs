using System;
using AcceleratedTool.XmlApi.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class DateTimeExtentionTests
    {
        [Test]
        public void TestThatDateTimeStringIsConvertedCorrectly()
        {
            var date = "12/29/2017";
            var result = date.ToApiDateFormat();
            Assert.AreEqual(new DateTime(2017, 12, 29), result);

            date = "10/9/2017";
            result = date.ToApiDateFormat();
            Assert.AreEqual(new DateTime(2017, 10, 9), result);
        }

        [Test]
        public void TestThatDateTimeIsConvertedToStringCorrectly()
        {
            var date = new DateTime(2017, 3, 1);
            var result = date.ToApiDateFormat();
            Assert.AreEqual("3/1/2017", result);

            var nullableDate = (DateTime?)new DateTime(2017, 1, 2);
            var nullableResult = nullableDate.ToApiDateFormat();
            Assert.AreEqual("1/2/2017", nullableResult);

            nullableDate = (DateTime?)null;
            nullableResult = nullableDate.ToApiDateFormat();
            Assert.AreEqual(string.Empty, nullableResult);
        }
    }
}
