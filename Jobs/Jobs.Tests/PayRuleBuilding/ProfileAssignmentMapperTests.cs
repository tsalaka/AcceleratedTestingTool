using System;
using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData.Mappers;
using Kronos.AcceleratedTool.Models.DbData;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PayRuleBuilding
{
    [TestFixture]
    public class ProfileAssignmentMapperTests
    {
        [Test]
        public void TestThatProfileAssignmentMapToLeaveProfileModelCorrectly()
        {
            var data = new List<ProfileAssignment>
            {
                new ProfileAssignment
                {
                    PersonFullName = "PersonFullName",
                    PersonNumber = "PersonNumber",
                    AccrualProfile = "AccrualProfile",
                    CompanyHireDate = new DateTime(2010, 1, 1),
                    LeaveProfile ="ProfileName"
                }
            };

            var mapper = new ProfileAssignmentMapper();
            var result = mapper.Map(data);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("PersonNumber", result.First().PersonNumber);
            Assert.AreEqual("PersonFullName", result.First().PersonFullName);
            Assert.AreEqual(new DateTime(2010, 1, 1), result.First().HireDate);
            Assert.AreEqual("ProfileName", result.First().ProfileName);
        }
    }
}
