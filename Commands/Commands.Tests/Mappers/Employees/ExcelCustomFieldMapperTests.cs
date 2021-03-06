﻿using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    [TestFixture]
    public class ExcelCustomFieldMapperTests
    {
        [Test]
        public void TestMappingForEmployeeCustomFieldEntity()
        {
            var inputDataList = new List<CustomData>
            {
                new CustomData
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber",
                        FirstName = "FirstName",
                        LastName = "LastName",
                        FullName = "FullName"
                    },
                    CustomDataTypeName = "CustomDataTypeName",
                    Text = "Text"
                },
                new CustomData
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber2",
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        FullName = "FullName2"
                    },
                    CustomDataTypeName = "CustomDataTypeName2",
                    Text = "Text2"
                }
            };

            var mapper = new ExcelCustomFieldMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(2, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].PersonNumber);
            Assert.AreEqual("LastName", mappedData[0].LastName);
            Assert.AreEqual("FirstName", mappedData[0].FirstName);
            Assert.AreEqual("CustomDataTypeName", mappedData[0].CustomDataTypeName);
            Assert.AreEqual("Text", mappedData[0].Text);

            Assert.AreEqual("PersonNumber2", mappedData[1].PersonNumber);
            Assert.AreEqual("LastName2", mappedData[1].LastName);
            Assert.AreEqual("FirstName2", mappedData[1].FirstName);
            Assert.AreEqual("CustomDataTypeName2", mappedData[1].CustomDataTypeName);
            Assert.AreEqual("Text2", mappedData[1].Text);
        }

        [Test]
        public void TestMappingForEmployeeCustomFieldEntityIfInputIsNullOrEmpty()
        {
            List<CustomData> inputDataList = null;
            var mapper = new ExcelCustomFieldMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.AreEqual(0, mappedData.Count);

            inputDataList = new List<CustomData>();
            mappedData = mapper.Map(inputDataList);
            Assert.AreEqual(0, mappedData.Count);
        }
    }
}
