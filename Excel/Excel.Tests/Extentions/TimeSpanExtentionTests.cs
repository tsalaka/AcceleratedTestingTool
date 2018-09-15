using System;
using AcceleratedTool.ExcelDocument.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests.Extentions
{
    [TestFixture]
    public class TimeSpanExtentionTests
    {
        [Test]
        public void TestThatDifferent24HourTimeStringIsConvertedCorrectly()
        {
            var time = "12:45";
            var result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(12, 45, 0), result);

            time = "22:35";
            result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(22, 35, 0), result);

            time = "23:59";
            result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(23, 59, 0), result);

            time = "24:00";
            result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), result);

            time = "40:00";
            result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(1, 16, 0, 0), result);

            time = "0.541666666666667";
            result = time.ToTimeFormat();
            Assert.AreEqual(new TimeSpan(13, 0, 0), result);
        }

        [Test]
        public void TestThatDifferentTimeIsConvertedToStringCorrectly()
        {
            var time = new TimeSpan(12, 45, 0);
            var result = time.ToTimeFormat();
            Assert.AreEqual("12:45", result);

            time = new TimeSpan(22, 35, 0);
            result = time.ToTimeFormat();
            Assert.AreEqual("22:35", result);

            time = new TimeSpan(23, 59, 0);
            result = time.ToTimeFormat();
            Assert.AreEqual("23:59", result);

            time = new TimeSpan(1, 0, 0, 0);
            result = time.ToTimeFormat();
            Assert.AreEqual("24:00", result);

            time = new TimeSpan(1, 16, 0, 23);
            result = time.ToTimeFormat();
            Assert.AreEqual("40:00", result);

            time = new TimeSpan(1, 23, 30, 32, 12);
            result = time.ToTimeFormat();
            Assert.AreEqual("47:30", result);

            time = new TimeSpan(1, 16, 0, 0);
            Assert.Throws<InvalidCastException>(() => time.ToTimeFormat("h:mmtt"));
        }
    }
}
