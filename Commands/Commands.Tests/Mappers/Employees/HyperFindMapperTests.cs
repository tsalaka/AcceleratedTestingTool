using System;
using System.Collections.Generic;
using System.Linq;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;
using HyperFindResult = AcceleratedTool.XmlApi.Contracts.Responses.HyperFindResult;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    /// <summary>
    /// Summary description for HyperFindMapperTest
    /// </summary>
    [TestFixture]
    public class HyperFindMapperTests
    {
        private readonly HyperFindMapper _mapper;
        public HyperFindMapperTests()
        {
            _mapper = new HyperFindMapper();
        }

        [Test]
        public void TestMappingForQueryAndResult()
        {
            var modelQuery = new HyperFindQuery
            {
                HyperFindQueryName = "query name",
                VisibilityCode = "code",
                QueryDateStart = new DateTime(2017, 03, 12),
                QueryDateEnd = new DateTime(2017, 03, 14)
            };

            var apiQuery = _mapper.GetQueryWrapper(modelQuery);
            Assert.AreEqual(modelQuery.QueryDateStart, apiQuery.QueryDateStart);
            Assert.AreEqual(modelQuery.QueryDateEnd, apiQuery.QueryDateEnd);
            Assert.AreEqual(modelQuery.VisibilityCode, apiQuery.VisibilityCode);
            Assert.AreEqual(modelQuery.HyperFindQueryName, apiQuery.HyperFindQueryName);

            var apiResult = new HyperFindResult
            {
                FullName = "Vasya Pupkin",
                PersonNumber = "MIH67868"
            };
            var modelResult = _mapper.GetResultWrapper(apiResult);
            Assert.AreEqual(apiResult.PersonNumber, modelResult.PersonNumber);
            Assert.AreEqual(apiResult.FullName, modelResult.FullName);
        }

        [Test]
        public void TestThatMappingListOfResultIsCorrect()
        {
            var results = new List<HyperFindResult>();
            results.Add(new HyperFindResult
            {
                FullName = "Vasya Pupkin",
                PersonNumber = "MIH67868"
            });
            results.Add(new HyperFindResult
            {
                FullName = "WEra AJK",
                PersonNumber = "PO09sjs"
            });

            var modelResults = _mapper.GetResultWrapper(results);
            Assert.IsNotNull(modelResults);
            Assert.AreEqual(2, modelResults.Count());
            Assert.AreEqual(results.First().FullName, modelResults.First().FullName);
            Assert.AreEqual(results.First().PersonNumber, modelResults.First().PersonNumber);
            Assert.AreEqual(results.Skip(1).Take(1).First().PersonNumber, modelResults.Skip(1).Take(1).First().PersonNumber);
        }
    }
}
