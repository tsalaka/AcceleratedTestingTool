using System;
using System.Collections.Generic;
using AcceleratedTool.Jobs.GetEmployeesData;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace AcceleratedTool.Jobs.Tests
{
    [TestFixture]
    public class EmployeeMapperTests
    {
        private List<Employee> _employees;

        [SetUp]
        public void SetUp()
        {
            _employees = new List<Employee>();
            _employees.Add(new Employee
            {
                PersonNumber = "PersonNumber",
                AccrualProfileName = "AccrualProfileName",
                BaseWageHourly = (decimal)0.99,
                BadgeNumber = "BadgeNumber",
                BirthDate = new DateTime(1985, 1, 15),
                HireDate = new DateTime(1985, 1, 1),
                FullTimePercentage = 122322342342,
                LastName = "LastName",
                FirstName = "FirstName",
                SupervisorFullName = "SupervisorName",
                SupervisorPersonNumber = "SupervisorPersonNumber",
                PayRuleName = "PayRuleName",
                TimeZoneName = "TimeZoneName",
                EmploymentTermName = "EmploymentTermName",
                EmpTermStartDate = new DateTime(2017, 2, 4),
                EmpTermEndDate = new DateTime(2017, 2, 5),
                HomeAccountName = "HomeAccountName",
                EmploymentStatusName = "EmploymentStatusName",
                AccessProfileName = "AccessProfileName",
                GroupScheduleName = "GroupScheduleName",
                ManagerAccessSetName = "ManagerAccessSetName",
                ManagerPayCodeName = "ManagerPayCodeName",
                ManagerViewPayCodeName = "ManagerViewPayCodeName",
                ManagerTransferSetName = "ManagerTransferSetName",
                ManagerApprovalSetName = "ManagerApprovalSetName",
                ManagerWorkRuleName = "ManagerWorkRuleName",
                PreferenceProfileName = "PreferenceProfileName",
                ProfessionalPayCodeName = "ProfessionalPayCodeName",
                ProfessionalTransferSetName = "ProfessionalTransferSetName",
                ProfessionalWorkRuleName = "ProfessionalWorkRuleName",
                ReportName = "ReportName",
                SchedulePatternName = "SchedulePatternName",
                ShiftCodeName = "ShiftCodeName",
                AvailabilityPatternName = "AvailabilityPatternName",
                TimeEntryTypeName = "TimeEntryTypeName",
                TransferEmployeeFlag = "TransferEmployeeFlag",
                DelegateProfileName = "DelegateProfileName",
                ApproveOvertimeFlag = true,
                HyperFindScheduleVisibilityName = "HyperFindScheduleVisibilityName",
                NotificationProfileName = "NotificationProfileName",
                ManagerAccessOrganizationSetName = "ManagerAccessOrganizationSetName",
                ManagerTransferOrganizationSetName = "ManagerTransferOrganizationSetName",
                ProfessionalTransferOrganizationSetName = "ProfessionalTransferOrganizationSetName",
                LogonProfileName = "LogonProfileName",
                UserName = "UserName",
                GDAPName = "GDAPName",
                GDAPRole = "GDAPRole",
                State = "State",
                Licenses = new List<EmployeeLicense>()
                {
                    new EmployeeLicense
                    {
                        ActiveFlag = true,
                        LicenseTypeName = "LicenseTypeName"
                    }
                },
                CustomDataList = new List<CustomData>
                {
                    new CustomData
                    {
                        Text = "Text1",
                        CustomDataTypeName = "CustomDataTypeName1"
                    },
                    new CustomData
                    {
                        Text = "Text1_2",
                        CustomDataTypeName = "CustomDataTypeName1_2"
                    }
                },
                CustomDates = new List<CustomDate>
                {
                    new CustomDate
                    {
                        Date = new DateTime(2017, 1, 15),
                        CustomDateTypeName = "CustomDateTypeName1"
                    },
                    new CustomDate
                    {
                        Date = new DateTime(2017, 1, 16),
                        CustomDateTypeName = "CustomDateTypeName1_2"
                    }
                }
            });

            _employees.Add(new Employee
            {
                PersonNumber = "PersonNumber2",
                LastName = "LastName2",
                FirstName = "FirstName2",
                Licenses = new List<EmployeeLicense>()
                {
                    new EmployeeLicense
                    {
                        ActiveFlag = false,
                        LicenseTypeName = "LicenseTypeName2"
                    },
                    new EmployeeLicense
                    {
                        ActiveFlag = true,
                        LicenseTypeName = "LicenseTypeName2_2"
                    },
                },
                CustomDataList = new List<CustomData>
                {
                    new CustomData
                    {
                        Text = "Text2",
                        CustomDataTypeName = "CustomDataTypeName2"
                    },
                    new CustomData
                    {
                        Text = "Text2_2",
                        CustomDataTypeName = "CustomDataTypeName2_2"
                    }
                },
                CustomDates = new List<CustomDate>
                {
                    new CustomDate
                    {
                        Date = new DateTime(2017, 1, 17),
                        CustomDateTypeName = "CustomDateTypeName2"
                    },
                    new CustomDate
                    {
                        Date = new DateTime(2017, 1, 18),
                        CustomDateTypeName = "CustomDateTypeName2_2"
                    }
                }
            });
        }

        [Test]
        public void TestMappingForEmployeeLicenseEntity()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapLicense(_employees);
            Assert.NotNull(mappedData);
            Assert.AreEqual(3, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].Person.PersonNumber);
            Assert.AreEqual(true, mappedData[0].ActiveFlag);
            Assert.AreEqual("LicenseTypeName", mappedData[0].LicenseTypeName);
            Assert.AreEqual("FirstName", mappedData[0].Person.FirstName);
            Assert.AreEqual("LastName", mappedData[0].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[1].Person.PersonNumber);
            Assert.AreEqual(false, mappedData[1].ActiveFlag);
            Assert.AreEqual("LicenseTypeName2", mappedData[1].LicenseTypeName);
            Assert.AreEqual("FirstName2", mappedData[1].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[1].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[2].Person.PersonNumber);
            Assert.AreEqual(true, mappedData[2].ActiveFlag);
            Assert.AreEqual("LicenseTypeName2_2", mappedData[2].LicenseTypeName);
            Assert.AreEqual("FirstName2", mappedData[2].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[2].Person.LastName);
        }

        [Test]
        public void TestMappingForEmployeeLicenseEntityIsInputIsEmpty()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapLicense(null);
            Assert.NotNull(mappedData);
        }

        [Test]
        public void TestMappingForCustomFieldEntity()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapCustomField(_employees);
            Assert.NotNull(mappedData);
            Assert.AreEqual(4, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].Person.PersonNumber);
            Assert.AreEqual("Text1", mappedData[0].Text);
            Assert.AreEqual("CustomDataTypeName1", mappedData[0].CustomDataTypeName);
            Assert.AreEqual("FirstName", mappedData[0].Person.FirstName);
            Assert.AreEqual("LastName", mappedData[0].Person.LastName);

            Assert.AreEqual("PersonNumber", mappedData[1].Person.PersonNumber);
            Assert.AreEqual("Text1_2", mappedData[1].Text);
            Assert.AreEqual("CustomDataTypeName1_2", mappedData[1].CustomDataTypeName);
            Assert.AreEqual("FirstName", mappedData[1].Person.FirstName);
            Assert.AreEqual("LastName", mappedData[1].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[2].Person.PersonNumber);
            Assert.AreEqual("Text2", mappedData[2].Text);
            Assert.AreEqual("CustomDataTypeName2", mappedData[2].CustomDataTypeName);
            Assert.AreEqual("FirstName2", mappedData[2].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[2].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[3].Person.PersonNumber);
            Assert.AreEqual("Text2_2", mappedData[3].Text);
            Assert.AreEqual("CustomDataTypeName2_2", mappedData[3].CustomDataTypeName);
            Assert.AreEqual("FirstName2", mappedData[3].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[3].Person.LastName);
        }

        [Test]
        public void TestMappingForCustomFieldEntityIsInputIsEmpty()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapCustomField(null);
            Assert.NotNull(mappedData);
        }

        [Test]
        public void TestMappingForCustomDateEntity()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapCustomDate(_employees);
            Assert.NotNull(mappedData);
            Assert.AreEqual(4, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].Person.PersonNumber);
            Assert.AreEqual(new DateTime(2017, 1, 15), mappedData[0].Date);
            Assert.AreEqual("CustomDateTypeName1", mappedData[0].CustomDateTypeName);
            Assert.AreEqual("FirstName", mappedData[0].Person.FirstName);
            Assert.AreEqual("LastName", mappedData[0].Person.LastName);

            Assert.AreEqual("PersonNumber", mappedData[1].Person.PersonNumber);
            Assert.AreEqual(new DateTime(2017, 1, 16), mappedData[1].Date);
            Assert.AreEqual("CustomDateTypeName1_2", mappedData[1].CustomDateTypeName);
            Assert.AreEqual("FirstName", mappedData[1].Person.FirstName);
            Assert.AreEqual("LastName", mappedData[1].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[2].Person.PersonNumber);
            Assert.AreEqual(new DateTime(2017, 1, 17), mappedData[2].Date);
            Assert.AreEqual("CustomDateTypeName2", mappedData[2].CustomDateTypeName);
            Assert.AreEqual("FirstName2", mappedData[2].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[2].Person.LastName);

            Assert.AreEqual("PersonNumber2", mappedData[3].Person.PersonNumber);
            Assert.AreEqual(new DateTime(2017, 1, 18), mappedData[3].Date);
            Assert.AreEqual("CustomDateTypeName2_2", mappedData[3].CustomDateTypeName);
            Assert.AreEqual("FirstName2", mappedData[3].Person.FirstName);
            Assert.AreEqual("LastName2", mappedData[3].Person.LastName);
        }

        [Test]
        public void TestMappingForCustomDateEntityIsInputIsEmpty()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapCustomDate(null);
            Assert.NotNull(mappedData);
        }

        [Test]
        public void TestMappingForPayRulePreEntity()
        {
            var employees = new List<Employee>();
            for(int i = 1; i <= 12; i++)
            {
                employees.Add(new Employee
                {
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    PersonNumber = "PersonNumber" + i,
                    PayRuleName = "PayRuleName1"
                });
            }
            for (int i = 13; i <= 24; i++)
            {
                employees.Add(new Employee
                {
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    PersonNumber = "PersonNumber" + i,
                    PayRuleName = "PayRuleName2"
                });
            }

            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapPayRulePre(employees);
            Assert.NotNull(mappedData);
            Assert.AreEqual(24, mappedData.Count);
            for (int i = 1; i <= 12; i++)
            {
                Assert.AreEqual("LastName" + i + ", " + "FirstName" + i, mappedData[i-1].FullName);
                Assert.AreEqual("PersonNumber" + i, mappedData[i-1].PersonNumber);
                Assert.AreEqual("PayRuleName1", mappedData[i-1].PayRuleName);
                Assert.AreEqual(i, mappedData[i-1].Sequence);
            }
            for (int i = 13; i <= 24; i++)
            {
                Assert.AreEqual("LastName" + i + ", " + "FirstName" + i, mappedData[i - 1].FullName);
                Assert.AreEqual("PersonNumber" + i, mappedData[i - 1].PersonNumber);
                Assert.AreEqual("PayRuleName2", mappedData[i - 1].PayRuleName);
                Assert.AreEqual(i-12, mappedData[i - 1].Sequence);
            }
        }

        [Test]
        public void TestMappingForPayRulePreEntityIsInputIsEmpty()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapPayRulePre(null);
            Assert.NotNull(mappedData);
        }

        [Test]
        public void TestMappingForPayRuleEntity()
        {
            var payRulePreList = new List<PayRulePre>();
            for (int i = 1; i <= 12; i++)
            {
                payRulePreList.Add(new PayRulePre
                {
                    FullName = "LastName" + i + ", " + "FirstName" + i,
                    PersonNumber = "PersonNumber" + i,
                    PayRuleName = "PayRuleName1",
                    Sequence = i
                });
            }
            for (int i = 13; i <= 24; i++)
            {
                payRulePreList.Add(new PayRulePre
                {
                    FullName = "LastName" + i + ", " + "FirstName" + i,
                    PersonNumber = "PersonNumber" + i,
                    PayRuleName = "PayRuleName2",
                    Sequence = i - 12
                });
            }

            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapPayRule(payRulePreList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(24, mappedData.Count);
            for (int i = 1; i <= 12; i++)
            {
                Assert.AreEqual("LastName" + i + ", " + "FirstName" + i, mappedData[i - 1].FullName);
                Assert.AreEqual("PersonNumber" + i, mappedData[i - 1].PersonNumber);
                Assert.AreEqual("PayRuleName1", mappedData[i - 1].PayRuleName);
                Assert.AreEqual(i, mappedData[i - 1].Sequence);

                Assert.AreEqual(GetTestNameBySequence(i), mappedData[i - 1].TestName);
            }
            for (int i = 13; i <= 24; i++)
            {
                Assert.AreEqual("LastName" + i + ", " + "FirstName" + i, mappedData[i - 1].FullName);
                Assert.AreEqual("PersonNumber" + i, mappedData[i - 1].PersonNumber);
                Assert.AreEqual("PayRuleName2", mappedData[i - 1].PayRuleName);
                Assert.AreEqual(GetTestNameBySequence(i - 12), mappedData[i - 1].TestName);
            }
        }

        private string GetTestNameBySequence(int sequence)
        {
            switch (sequence)
            {
                case 1:
                    return "Exception Test";
                case 2:
                    return "Overtime Test";
                case 3:
                    return "Timecard Test";
                case 4:
                    return "Shift Guarantee Test";
                case 5:
                    return "Punch Round Test";
                default:
                    return "Other Tests";
            }
        }

        [Test]
        public void TestMappingForPayRuleEntityIsInputIsEmpty()
        {
            var mapper = new EmployeeMapper();
            var mappedData = mapper.MapPayRule(null);
            Assert.NotNull(mappedData);
        }
    }
}
