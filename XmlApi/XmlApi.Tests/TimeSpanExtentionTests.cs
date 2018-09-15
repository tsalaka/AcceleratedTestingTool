using System;
using AcceleratedTool.XmlApi.Extentions;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class TimeSpanExtentionTests
    {
        [Test]
        public void TestThatDifferent24HourTimeStringIsConvertedCorrectly()
        {
            var time = "12:45";
            var result = time.ToApi24HourTimeFormat();
            Assert.AreEqual(new TimeSpan(12, 45, 0), result);

            time = "22:35";
            result = time.ToApi24HourTimeFormat();
            Assert.AreEqual(new TimeSpan(22, 35, 0), result);

            time = "23:59";
            result = time.ToApi24HourTimeFormat();
            Assert.AreEqual(new TimeSpan(23, 59, 0), result);

            time = "24:00";
            result = time.ToApi24HourTimeFormat();
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), result);
        }

        [Test]
        public void TestThatDifferent12HourTimeStringIsConvertedCorrectly()
        {
            var time = "12:45AM";
            var result = time.ToApi12HourTimeFormat();
            Assert.AreEqual(new TimeSpan(0, 45, 0), result);

            time = "12:35PM";
            result = time.ToApi12HourTimeFormat();
            Assert.AreEqual(new TimeSpan(12, 35, 0), result);

            time = "2:35PM";
            result = time.ToApi12HourTimeFormat();
            Assert.AreEqual(new TimeSpan(14, 35, 0), result);

            time = "0:00AM";
            result = time.ToApi12HourTimeFormat();
            Assert.AreEqual(new TimeSpan(0, 0, 0), result);

            time = "0:00PM";
            result = time.ToApi12HourTimeFormat();
            Assert.AreEqual(new TimeSpan(12, 0, 0), result);
        }

        [Test]
        public void TestThatMoreThan24HoursStringIsConvertedCorrectly()
        {
            var time = "40:00";
            var result = time.ToApi24HourTimeFormat();
            Assert.AreEqual(new TimeSpan(1, 16, 0, 0), result);
        }

        [Test]
        public void TestThatMoreThan24HoursTimeIsConvertedToStringCorrectly()
        {
            var time = new TimeSpan(12, 45, 0);
            var result = time.ToApi24HourTimeFormat();
            Assert.AreEqual("12:45", result);

            time = new TimeSpan(22, 35, 0);
            result = time.ToApi24HourTimeFormat();
            Assert.AreEqual("22:35", result);

            time = new TimeSpan(23, 59, 0);
            result = time.ToApi24HourTimeFormat();
            Assert.AreEqual("23:59", result);

            time = new TimeSpan(1, 16, 13, 0);
            Assert.Throws<InvalidCastException>(() => time.ToApi24HourTimeFormat());

            Assert.Throws<InvalidCastException>(() => ((TimeSpan?)null).ToApi24HourTimeFormat());
        }
    }
}
