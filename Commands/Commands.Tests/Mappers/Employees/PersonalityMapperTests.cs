using System;
using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.XmlApi.Contracts.Responses;
using AcceleratedTool.XmlApi.Contracts.Responses.JobAssignments;
using AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations;
using AcceleratedTool.XmlApi.Contracts.Responses.Users;
using NUnit.Framework;
using HyperFindResult = AcceleratedTool.Models.Employees.HyperFindResult;
using Personality = AcceleratedTool.XmlApi.Contracts.Responses.Personality;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    [TestFixture]
    public class PersonalityMapperTests
    {
        public void TestMappingForPersonalityEntity()
        {
            var inputDataList = new List<HyperFindResult>
            {
                new HyperFindResult
                {
                    PersonNumber = "PersonNumber",
                    FullName = "FullName"
                },
                new HyperFindResult
                {
                    PersonNumber = "PersonNumber2",
                    FullName = "FullName2"
                }
            };

            var mapper = new PersonalityMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(2, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].Identity.PersonIdentity.PersonNumber);
            Assert.AreEqual("PersonNumber2", mappedData[1].Identity.PersonIdentity.PersonNumber);
        }

        [Test]
        public void TestMappingForEmployeeEntity()
        {
            var personality = new Personality
            {
                Identity = new Identity
                {
                    PersonIdentity = new PersonIdentity
                    {
                        PersonNumber = "PersonNumber"
                    }
                },
                PersonInformationData = new PersonInformationData
                {
                    PersonInformation = new PersonInformation
                    {
                        PersonData = new PersonData
                        {
                            Person = new Person
                            {
                                LastName = "LastName",
                                FirstName = "FirstName",
                                AccrualProfileName = "AccrualProfileName",
                                BirthDate = new DateTime(1985, 1, 2),
                                HireDate = new DateTime(1985, 1, 1),
                                FullTimePercentage = 122322342342,
                                BaseWageHourly = (decimal)12.45
                            }
                        }
                    }
                },
                JobAssignmentData = new JobAssignmentData
                {
                    JobAssignment = new JobAssignment
                    {
                        JobAssignmentDetailsData = new JobAssignmentDetailsData
                        {
                            JobAssignmentDetails = new JobAssignmentDetails
                            {
                                SupervisorName = "SupervisorName",
                                SupervisorPersonNumber = "SupervisorPersonNumber",
                                PayRuleName = "PayRuleName",
                                TimeZoneName = "TimeZoneName"
                            }
                        }
                    },
                    EmploymentTermAssignments = new List<EmploymentTermAssignment>()
                    {
                        new EmploymentTermAssignment
                        {
                            Name = "EmploymentTermName",
                            StartDate = new DateTime(2017, 2, 4),
                            EndDate = new DateTime(2017, 2, 5)
                        }
                    }
                }
            };

            personality.PersonInformationData.PersonInformation.HomeAccounts = new List<HomeAccount>
            {
                new HomeAccount
                {
                    LaborAccountName = "LaborAccountName"
                }
            };

            personality.PersonInformationData.PersonInformation.EmploymentStatusList = new List<EmploymentStatus>
            {
                new EmploymentStatus
                {
                    EmploymentStatusName = "EmploymentStatusName"
                }
            };

            personality.PersonInformationData.PersonInformation.BadgeAssignments = new List<BadgeAssignment>
            {
                new BadgeAssignment
                {
                    BadgeNumber = "BadgeNumber"
                }
            };

            personality.PersonInformationData.PersonInformation.AccessAssignmentData = new AccessAssignmentData
            {
                AccessAssignment = new AccessAssignment
                {
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
                    NotificationProfileName = "NotificationProfileName"
                }
            };

            personality.PersonInformationData.PersonInformation.PersonAccessAssignments = new List
                <PersonAccessAssignment>
                {
                    new PersonAccessAssignment
                    {
                        ManagerAccessOrganizationSetName = "ManagerAccessOrganizationSetName",
                        ManagerTransferOrganizationSetName = "ManagerTransferOrganizationSetName",
                        ProfessionalTransferOrganizationSetName = "ProfessionalTransferOrganizationSetName"
                    }
                };

            personality.UserData = new UserData
            {
                User = new User
                {
                    UserAccountData = new UserAccountData
                    {
                        UserAccount = new UserAccount
                        {
                            LogonProfileName = "LogonProfileName",
                            UserName = "UserName"
                        }
                    }
                }
            };

            personality.GDAPAssignments = new List<GDAPAssignment>
            {
                new GDAPAssignment
                {
                    GDAPName = "GDAPName",
                    Role = "GDAPRole"
                }
            };

            personality.PersonInformationData.PersonInformation.PostalAddresses = new List<PostalAddress>
            {
                new PostalAddress
                {
                    State = "State"
                }
            };

            personality.PersonInformationData.PersonInformation.PersonLicenseTypes = new List<PersonLicenseType>
            {
                new PersonLicenseType
                {
                    ActiveFlag = true,
                    LicenseTypeName = "LicenseTypeName"
                }
            };

            personality.PersonInformationData.PersonInformation.CustomDataList = new List<CustomData>
            {
                new CustomData
                {
                    CustomDataTypeName = "CustomDataTypeName",
                    Text = "Text"
                }
            };

            personality.PersonInformationData.PersonInformation.CustomDates = new List<CustomDate>
            {
                new CustomDate
                {
                    CustomDateTypeName = "CustomDateTypeName",
                    Date = new DateTime(2017, 2, 8)
                }
            };

            var inputDataList = new List<Personality>();
            inputDataList.Add(personality);

            var mapper = new PersonalityMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(1, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].PersonNumber);
            Assert.AreEqual("LastName", mappedData[0].LastName);
            Assert.AreEqual("FirstName", mappedData[0].FirstName);
            Assert.AreEqual("AccrualProfileName", mappedData[0].AccrualProfileName);
            Assert.AreEqual(new DateTime(1985, 1, 2), mappedData[0].BirthDate);
            Assert.AreEqual(new DateTime(1985, 1, 1), mappedData[0].HireDate);
            Assert.AreEqual(122322342342, mappedData[0].FullTimePercentage);
            Assert.AreEqual((decimal)12.45, mappedData[0].BaseWageHourly);
            Assert.AreEqual("SupervisorName", mappedData[0].SupervisorFullName);
            Assert.AreEqual("SupervisorPersonNumber", mappedData[0].SupervisorPersonNumber);
            Assert.AreEqual("PayRuleName", mappedData[0].PayRuleName);
            Assert.AreEqual("TimeZoneName", mappedData[0].TimeZoneName);
            Assert.AreEqual("EmploymentTermName", mappedData[0].EmploymentTermName);
            Assert.AreEqual(new DateTime(2017, 2, 4), mappedData[0].EmpTermStartDate);
            Assert.AreEqual(new DateTime(2017, 2, 5), mappedData[0].EmpTermEndDate);
            Assert.AreEqual("LaborAccountName", mappedData[0].HomeAccountName);
            Assert.AreEqual("EmploymentStatusName", mappedData[0].EmploymentStatusName);
            Assert.AreEqual("BadgeNumber", mappedData[0].BadgeNumber);
            Assert.AreEqual("AccessProfileName", mappedData[0].AccessProfileName);
            Assert.AreEqual("GroupScheduleName", mappedData[0].GroupScheduleName);
            Assert.AreEqual("ManagerAccessSetName", mappedData[0].ManagerAccessSetName);
            Assert.AreEqual("ManagerPayCodeName", mappedData[0].ManagerPayCodeName);
            Assert.AreEqual("ManagerViewPayCodeName", mappedData[0].ManagerViewPayCodeName);
            Assert.AreEqual("ManagerTransferSetName", mappedData[0].ManagerTransferSetName);
            Assert.AreEqual("ManagerApprovalSetName", mappedData[0].ManagerApprovalSetName);
            Assert.AreEqual("ManagerWorkRuleName", mappedData[0].ManagerWorkRuleName);
            Assert.AreEqual("PreferenceProfileName", mappedData[0].PreferenceProfileName);
            Assert.AreEqual("ProfessionalPayCodeName", mappedData[0].ProfessionalPayCodeName);
            Assert.AreEqual("ProfessionalTransferSetName", mappedData[0].ProfessionalTransferSetName);
            Assert.AreEqual("ProfessionalWorkRuleName", mappedData[0].ProfessionalWorkRuleName);
            Assert.AreEqual("ReportName", mappedData[0].ReportName);
            Assert.AreEqual("SchedulePatternName", mappedData[0].SchedulePatternName);
            Assert.AreEqual("ShiftCodeName", mappedData[0].ShiftCodeName);
            Assert.AreEqual("AvailabilityPatternName", mappedData[0].AvailabilityPatternName);
            Assert.AreEqual("TimeEntryTypeName", mappedData[0].TimeEntryTypeName);
            Assert.AreEqual("TransferEmployeeFlag", mappedData[0].TransferEmployeeFlag);
            Assert.AreEqual("DelegateProfileName", mappedData[0].DelegateProfileName);
            Assert.AreEqual(true, mappedData[0].ApproveOvertimeFlag);
            Assert.AreEqual("HyperFindScheduleVisibilityName", mappedData[0].HyperFindScheduleVisibilityName);
            Assert.AreEqual("NotificationProfileName", mappedData[0].NotificationProfileName);
            Assert.AreEqual("ManagerAccessOrganizationSetName", mappedData[0].ManagerAccessOrganizationSetName);
            Assert.AreEqual("ManagerTransferOrganizationSetName", mappedData[0].ManagerTransferOrganizationSetName);
            Assert.AreEqual("ProfessionalTransferOrganizationSetName", mappedData[0].ProfessionalTransferOrganizationSetName);
            Assert.AreEqual("LogonProfileName", mappedData[0].LogonProfileName);
            Assert.AreEqual("UserName", mappedData[0].UserName);
            Assert.AreEqual("GDAPName", mappedData[0].GDAPName);
            Assert.AreEqual("GDAPRole", mappedData[0].GDAPRole);
            Assert.AreEqual("State", mappedData[0].State);
            Assert.AreEqual("LicenseTypeName", mappedData[0].Licenses[0].LicenseTypeName);
            Assert.AreEqual(true, mappedData[0].Licenses[0].ActiveFlag);
            Assert.AreEqual("CustomDataTypeName", mappedData[0].CustomDataList[0].CustomDataTypeName);
            Assert.AreEqual("Text", mappedData[0].CustomDataList[0].Text);
            Assert.AreEqual("CustomDateTypeName", mappedData[0].CustomDates[0].CustomDateTypeName);
            Assert.AreEqual(new DateTime(2017, 2, 8), mappedData[0].CustomDates[0].Date);
        }

        [Test]
        public void TestMappingForEmployeeIfInputIsEmpty()
        {
            var personalities = new List<Personality>
            {
                new Personality()
            };
            var mapper = new PersonalityMapper();

            var mappedData = mapper.Map(personalities);
            Assert.NotNull(mappedData);
            Assert.AreEqual(1, mappedData.Count);
            Assert.IsNull(mappedData[0].PersonNumber);
            Assert.IsNull(mappedData[0].LastName);
            Assert.IsNull(mappedData[0].FirstName);
            Assert.IsNull(mappedData[0].AccrualProfileName);
            Assert.IsNull(mappedData[0].BirthDate);
            Assert.IsNull(mappedData[0].HireDate);
            Assert.IsNull(mappedData[0].FullTimePercentage);
            Assert.IsNull(mappedData[0].BaseWageHourly);
            Assert.IsNull(mappedData[0].SupervisorFullName);
            Assert.IsNull(mappedData[0].SupervisorPersonNumber);
            Assert.IsNull(mappedData[0].PayRuleName);
            Assert.IsNull(mappedData[0].TimeZoneName);
            Assert.IsNull(mappedData[0].EmploymentTermName);
            Assert.IsNull(mappedData[0].EmpTermStartDate);
            Assert.IsNull(mappedData[0].EmpTermEndDate);
            Assert.IsNull(mappedData[0].HomeAccountName);
            Assert.IsNull(mappedData[0].EmploymentStatusName);
            Assert.IsNull(mappedData[0].BadgeNumber);
            Assert.IsNull(mappedData[0].AccessProfileName);
            Assert.IsNull(mappedData[0].GroupScheduleName);
            Assert.IsNull(mappedData[0].ManagerAccessSetName);
            Assert.IsNull(mappedData[0].ManagerPayCodeName);
            Assert.IsNull(mappedData[0].ManagerViewPayCodeName);
            Assert.IsNull(mappedData[0].ManagerTransferSetName);
            Assert.IsNull(mappedData[0].ManagerApprovalSetName);
            Assert.IsNull(mappedData[0].ManagerWorkRuleName);
            Assert.IsNull(mappedData[0].PreferenceProfileName);
            Assert.IsNull(mappedData[0].ProfessionalPayCodeName);
            Assert.IsNull(mappedData[0].ProfessionalTransferSetName);
            Assert.IsNull(mappedData[0].ProfessionalWorkRuleName);
            Assert.IsNull(mappedData[0].ReportName);
            Assert.IsNull(mappedData[0].SchedulePatternName);
            Assert.IsNull(mappedData[0].ShiftCodeName);
            Assert.IsNull(mappedData[0].AvailabilityPatternName);
            Assert.IsNull(mappedData[0].TimeEntryTypeName);
            Assert.IsNull(mappedData[0].TransferEmployeeFlag);
            Assert.IsNull(mappedData[0].DelegateProfileName);
            Assert.IsNull(mappedData[0].ApproveOvertimeFlag);
            Assert.IsNull(mappedData[0].HyperFindScheduleVisibilityName);
            Assert.IsNull(mappedData[0].NotificationProfileName);
            Assert.IsNull(mappedData[0].ManagerAccessOrganizationSetName);
            Assert.IsNull(mappedData[0].ManagerTransferOrganizationSetName);
            Assert.IsNull(mappedData[0].ProfessionalTransferOrganizationSetName);
            Assert.IsNull(mappedData[0].LogonProfileName);
            Assert.IsNull(mappedData[0].UserName);
            Assert.IsNull(mappedData[0].GDAPName);
            Assert.IsNull(mappedData[0].GDAPRole);
            Assert.IsNull(mappedData[0].State);
            Assert.IsNull(mappedData[0].Licenses);
            Assert.IsNull(mappedData[0].CustomDataList);
            Assert.IsNull(mappedData[0].CustomDates);
        }
    }
}
