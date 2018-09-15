using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData.Mappers;
using Kronos.AcceleratedTool.Models.DbData;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PayRuleBuilding
{
    [TestFixture]
    public class WfsPayRuleMapperTests
    {
        [Test]
        public void TestThatEmployeeRuleSetMapToWfsProfileModelCorrectly()
        {
            var data = new List<EmployeeRuleSet>
            {
                new EmployeeRuleSet
                {
                    Sequence = 1,
                    EmployeeRuleSetName = "EmployeeRuleSetName",
                    PersonFullName = "PersonFullName",
                    PersonNumber = "PersonNumber"
                }
            };

            var mapper = new WfsPayRuleMapper();
            var result = mapper.Map(data);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("PersonFullName", result.First().PersonFullName);
            Assert.AreEqual("PersonNumber", result.First().PersonNumber);
            Assert.AreEqual("EmployeeRuleSetName", result.First().EmployeeRuleSetName);
        }
    }
}
