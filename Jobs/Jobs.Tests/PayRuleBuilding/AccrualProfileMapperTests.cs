using System;
using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData.Mappers;
using Kronos.AcceleratedTool.Models.DbData;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PayRuleBuilding
{
    [TestFixture]
    public class AccrualProfileMapperTests
    {
        [Test]
        public void TestThatDbModeMapToPayRuleBuildingModelCorrectly()
        {
            var data = new List<AccrualProfile>
            {
                new AccrualProfile
                {
                    AccrualProfileName = "AccrualProfileName",
                    PersonFullName = "PersonFullName",
                    CompanyHireDate = new DateTime(2000, 1, 6),
                    PersonNumber = "PersonNumber"
                }
            };

            var mapper = new AccrualProfileMapper();
            var result = mapper.Map(data);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("PersonFullName", result.First().PersonFullName);
            Assert.AreEqual("PersonNumber", result.First().PersonNumber);
            Assert.AreEqual("AccrualProfileName", result.First().AccrualProfileName);
            Assert.AreEqual(new DateTime(2000, 1, 6), result.First().HireDate);
        }
    }
}
