using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData.Mappers;
using Kronos.AcceleratedTool.Models.DbData;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PayRuleBuilding
{
    [TestFixture]
    public class EmployeePerWatMapperTests
    {
        [Test]
        public void TestThatAttendanceProfileMapToWatModelCorrectly()
        {
            var data = new List<AttendanceProfile>
            {
                new AttendanceProfile
                {
                    PersonFullName = "PersonFullName",
                    PersonNumber = "PersonNumber",
                    ProfileDescription = "ProfileDescription",
                    ProfileName = "ProfileName",
                    Sequence = 1
                }
            };

            var mapper = new EmployeePerWatMapper();
            var result = mapper.Map(data);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.First().Sequence);
            Assert.AreEqual("PersonNumber", result.First().PersonNumber);
            Assert.AreEqual("PersonFullName", result.First().PersonFullName);
            Assert.AreEqual("ProfileDescription", result.First().ProfileDescription);
            Assert.AreEqual("ProfileName", result.First().ProfileName);
        }
    }
}
