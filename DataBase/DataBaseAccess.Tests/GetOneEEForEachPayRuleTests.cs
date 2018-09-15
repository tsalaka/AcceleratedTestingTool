using System.Collections.Generic;
using Kronos.AcceleratedTool.DataAccess.Common;
using Kronos.AcceleratedTool.DataAccess.Common.DataContext;
using Kronos.AcceleratedTool.DataBaseAccess.Queries.GetEeForEachPayRule;
using Moq;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.DataBaseAccess.Tests
{
    [TestFixture]
    public class GetOneEeForEachPayRuleTests
    {
        private readonly Mock<IDataContext> _dataContextMock = new Mock<IDataContext>();

        [Test]
        public void TestGetOneEeForEachPayRuleQuery()
        {
            var dataResult = new List<OneEeForEachPayRuleResult>();
            dataResult.Add(
                new OneEeForEachPayRuleResult
                {
                    FullName = "FullName",
                    PayRuleName = "PayRuleName",
                    PersonNumber = "PersonNumber",
                    Sequence = 1
                }
            );
            dataResult.Add(
               new OneEeForEachPayRuleResult
               {
                   FullName = "FullName2",
                   PayRuleName = "PayRuleName",
                   PersonNumber = "PersonNumber2",
                   Sequence = 2
               }
           );
            dataResult.Add(
               new OneEeForEachPayRuleResult
               {
                   FullName = "FullName3",
                   PayRuleName = "PayRuleName2",
                   PersonNumber = "PersonNumber3",
                   Sequence = 1
               }
           );
            _dataContextMock.Setup(w => w.ExecuteQuery<OneEeForEachPayRuleResult>(It.IsAny<QueryScriptDictionary>(), null, 0)).Returns(dataResult);
            var query = new GetOneEeForEachPayRuleQuery(_dataContextMock.Object);
            var result = query.Execute();
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("FullName", result[0].FullName);
            Assert.AreEqual("PayRuleName", result[0].PayRuleName);
            Assert.AreEqual("PersonNumber", result[0].PersonNumber);
            Assert.AreEqual(1, result[0].Sequence);

            Assert.AreEqual("FullName2", result[1].FullName);
            Assert.AreEqual("PayRuleName", result[1].PayRuleName);
            Assert.AreEqual("PersonNumber2", result[1].PersonNumber);
            Assert.AreEqual(2, result[1].Sequence);

            Assert.AreEqual("FullName3", result[2].FullName);
            Assert.AreEqual("PayRuleName2", result[2].PayRuleName);
            Assert.AreEqual("PersonNumber3", result[2].PersonNumber);
            Assert.AreEqual(1, result[2].Sequence);
        }

        [Test]
        public void TestGetOneEeForEachPayRuleQueryIfResultIsEmpty()
        {
            _dataContextMock.Setup(w => w.ExecuteQuery<OneEeForEachPayRuleResult>(It.IsAny<QueryScriptDictionary>(), null, 0)).Returns(new List<OneEeForEachPayRuleResult>());
            var query = new GetOneEeForEachPayRuleQuery(_dataContextMock.Object);
            var result = query.Execute();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
