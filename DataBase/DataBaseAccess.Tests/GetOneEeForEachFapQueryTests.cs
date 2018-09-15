using System.Collections.Generic;
using Kronos.AcceleratedTool.DataAccess.Common;
using Kronos.AcceleratedTool.DataAccess.Common.DataContext;
using Kronos.AcceleratedTool.DataBaseAccess.Queries.GetEeForEachFap;
using Moq;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.DataBaseAccess.Tests
{
    [TestFixture]
    public class GetOneEeForEachFapQueryTests
    {
        private readonly Mock<IDataContext> _dataContextMock = new Mock<IDataContext>();

        [Test]
        public void TestGetOneEeForEachFapQuery()
        {
            var dataResult = new List<OneEeForEachFapResult>();
            dataResult.Add(
                new OneEeForEachFapResult
                {
                    FullName = "FullName",
                    AccessProfileName = "AccessProfileName",
                    PersonNumber = "PersonNumber"
                }
            );
            dataResult.Add(
               new OneEeForEachFapResult
               {
                   FullName = "FullName2",
                   AccessProfileName = "AccessProfileName2",
                   PersonNumber = "PersonNumber2"
               }
           );
            dataResult.Add(
               new OneEeForEachFapResult
               {
                   FullName = "FullName3",
                   AccessProfileName = "AccessProfileName3",
                   PersonNumber = "PersonNumber3",
               }
           );
            _dataContextMock.Setup(w => w.ExecuteQuery<OneEeForEachFapResult>(It.IsAny<QueryScriptDictionary>(), null, 0)).Returns(dataResult);
            var query = new GetOneEeForEachFapQuery(_dataContextMock.Object);
            var result = query.Execute();
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("FullName", result[0].FullName);
            Assert.AreEqual("AccessProfileName", result[0].AccessProfileName);
            Assert.AreEqual("PersonNumber", result[0].PersonNumber);

            Assert.AreEqual("FullName2", result[1].FullName);
            Assert.AreEqual("AccessProfileName2", result[1].AccessProfileName);
            Assert.AreEqual("PersonNumber2", result[1].PersonNumber);

            Assert.AreEqual("FullName3", result[2].FullName);
            Assert.AreEqual("AccessProfileName3", result[2].AccessProfileName);
            Assert.AreEqual("PersonNumber3", result[2].PersonNumber);
        }

        [Test]
        public void TestGetOneEeForEachFapQueryIfResultIsEmpty()
        {
            _dataContextMock.Setup(w => w.ExecuteQuery<OneEeForEachFapResult>(It.IsAny<QueryScriptDictionary>(), null, 0)).Returns(new List<OneEeForEachFapResult>());
            var query = new GetOneEeForEachFapQuery(_dataContextMock.Object);
            var result = query.Execute();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
