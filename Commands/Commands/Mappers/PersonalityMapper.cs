using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AcceleratedTool.Commands.Mappers.Resolvers;
using AcceleratedTool.Models.Employees;
using AcceleratedTool.XmlApi.Contracts.Responses;
using HyperFindResult = AcceleratedTool.Models.Employees.HyperFindResult;
using Personality = AcceleratedTool.XmlApi.Contracts.Requests.Personality;
using PersonIdentity = AcceleratedTool.Models.Employees.PersonIdentity;

namespace AcceleratedTool.Commands.Mappers
{
    public class PersonalityMapper
    {
        public PersonalityMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HyperFindResult, Personality>()
                    .ForMember(dest => dest.Identity, opt => opt.ResolveUsing<PersonalityIdenitityResolver>());
                cfg.CreateMap<PersonLicenseType, EmployeeLicense>();
                cfg.CreateMap<XmlApi.Contracts.Responses.PersonInformations.CustomData, CustomData>();
                cfg.CreateMap<XmlApi.Contracts.Responses.PersonInformations.CustomDate, CustomDate>();

                cfg.CreateMap<PersonIdentity, XmlApi.Contracts.Requests.PersonIdentity>();
                CreatePersonalityToEmployeeMapper(cfg);
            });
        }

        public List<Personality> Map(List<HyperFindResult> data)
        {
            var personalityData = Mapper.Map<List<HyperFindResult>, List<Personality>>(data);
            return personalityData;
        }

        public List<Models.Employees.Employee> Map(List<XmlApi.Contracts.Responses.Personality> data)
        {
            var personalityData = Mapper.Map<List<XmlApi.Contracts.Responses.Personality>, List<Models.Employees.Employee>>(data);
            return personalityData;
        }

        private void CreatePersonalityToEmployeeMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<XmlApi.Contracts.Responses.Personality, Models.Employees.Employee>()
                   .ForMember(dest => dest.PersonNumber, opt =>
                    {
                        opt.PreCondition(s => s.Identity != null && s.Identity.PersonIdentity != null);
                        opt.MapFrom(src => src.Identity.PersonIdentity.PersonNumber);
                    })
                   .ForMember(dest => dest.LastName, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.LastName);
                    })
                   .ForMember(dest => dest.FirstName, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.FirstName);
                    })
                   .ForMember(dest => dest.AccrualProfileName, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.AccrualProfileName);
                    })
                   .ForMember(dest => dest.BirthDate, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.BirthDate);
                    })
                   .ForMember(dest => dest.HireDate, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.HireDate);
                    })
                   .ForMember(dest => dest.FullTimePercentage, opt =>
                    {
                        opt.PreCondition(s => IsPersonNotNull(s));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.FullTimePercentage);
                    })
                   .ForMember(dest => dest.BaseWageHourly, opt =>
                   {
                       opt.PreCondition(s => IsPersonNotNull(s));
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonData.Person.BaseWageHourly);
                   })

                   .ForMember(dest => dest.SupervisorFullName, opt =>
                    {
                        opt.PreCondition(s => IsJobAssignmentDetailsNotNull(s));
                        opt.MapFrom(src => src.JobAssignmentData.JobAssignment.JobAssignmentDetailsData.JobAssignmentDetails.SupervisorName);
                    })
                   .ForMember(dest => dest.SupervisorPersonNumber, opt =>
                    {
                        opt.PreCondition(s => IsJobAssignmentDetailsNotNull(s));
                        opt.MapFrom(src => src.JobAssignmentData.JobAssignment.JobAssignmentDetailsData.JobAssignmentDetails.SupervisorPersonNumber);
                    })
                   .ForMember(dest => dest.PayRuleName, opt =>
                    {
                        opt.PreCondition(s => IsJobAssignmentDetailsNotNull(s));
                        opt.MapFrom(src => src.JobAssignmentData.JobAssignment.JobAssignmentDetailsData.JobAssignmentDetails.PayRuleName);
                    })
                   .ForMember(dest => dest.TimeZoneName, opt =>
                    {
                        opt.PreCondition(s => IsJobAssignmentDetailsNotNull(s));
                        opt.MapFrom(src => src.JobAssignmentData.JobAssignment.JobAssignmentDetailsData.JobAssignmentDetails.TimeZoneName);
                    })
                   .ForMember(dest => dest.EmploymentTermName, opt =>
                   {
                       opt.PreCondition(s => IsEmploymentTermAssignmentsNotNull(s));
                       opt.MapFrom(src => src.JobAssignmentData.EmploymentTermAssignments.First().Name);
                   })
                   .ForMember(dest => dest.EmpTermStartDate, opt =>
                   {
                       opt.PreCondition(s => IsEmploymentTermAssignmentsNotNull(s));
                       opt.MapFrom(src => src.JobAssignmentData.EmploymentTermAssignments.First().StartDate);
                   })
                   .ForMember(dest => dest.EmpTermEndDate, opt =>
                   {
                       opt.PreCondition(s => IsEmploymentTermAssignmentsNotNull(s));
                       opt.MapFrom(src => src.JobAssignmentData.EmploymentTermAssignments.First().EndDate);
                   })

                   .ForMember(dest => dest.HomeAccountName, opt =>
                   {
                       opt.PreCondition(src => IsHomeAccountsNotNull(src));
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.HomeAccounts.First().LaborAccountName);
                   })

                   .ForMember(dest => dest.EmploymentStatusName, opt =>
                   {
                       opt.PreCondition(src => IsEmploymentStatusListNotNull(src));
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.EmploymentStatusList.First().EmploymentStatusName);
                   })

                   .ForMember(dest => dest.BadgeNumber, opt =>
                   {
                       opt.PreCondition(src => IsBadgeAssignmentsNotNull(src));
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.BadgeAssignments.First().BadgeNumber);
                   })
                   .ForMember(dest => dest.AccessProfileName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.AccessProfileName);
                    })
                   .ForMember(dest => dest.GroupScheduleName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.GroupScheduleName);
                    })
                   .ForMember(dest => dest.ManagerAccessSetName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerAccessSetName);
                    })
                   .ForMember(dest => dest.ManagerPayCodeName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerPayCodeName);
                    })
                   .ForMember(dest => dest.ManagerViewPayCodeName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerViewPayCodeName);
                    })
                   .ForMember(dest => dest.ManagerTransferSetName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerTransferSetName);
                    })
                   .ForMember(dest => dest.ManagerApprovalSetName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerApprovalSetName);
                    })
                   .ForMember(dest => dest.ManagerWorkRuleName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ManagerWorkRuleName);
                    })
                   .ForMember(dest => dest.PreferenceProfileName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.PreferenceProfileName);
                    })
                   .ForMember(dest => dest.ProfessionalPayCodeName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ProfessionalPayCodeName);
                    })
                   .ForMember(dest => dest.ProfessionalTransferSetName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ProfessionalTransferSetName);
                    })
                   .ForMember(dest => dest.ProfessionalWorkRuleName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ProfessionalWorkRuleName);
                    })
                   .ForMember(dest => dest.ReportName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ReportName);
                    })
                   .ForMember(dest => dest.SchedulePatternName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.SchedulePatternName);
                    })
                   .ForMember(dest => dest.ShiftCodeName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ShiftCodeName);
                    })
                   .ForMember(dest => dest.AvailabilityPatternName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.AvailabilityPatternName);
                    })
                   .ForMember(dest => dest.TimeEntryTypeName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.TimeEntryTypeName);
                    })
                   .ForMember(dest => dest.TransferEmployeeFlag, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.TransferEmployeeFlag);
                    })
                   .ForMember(dest => dest.DelegateProfileName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.DelegateProfileName);
                    })
                   .ForMember(dest => dest.ApproveOvertimeFlag, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.ApproveOvertimeFlag);
                    })
                   .ForMember(dest => dest.HyperFindScheduleVisibilityName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.HyperFindScheduleVisibilityName);
                    })
                   .ForMember(dest => dest.NotificationProfileName, opt =>
                    {
                        opt.PreCondition(src => IsAccessAssignmentNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment.NotificationProfileName);
                    })

                   .ForMember(dest => dest.ManagerAccessOrganizationSetName, opt =>
                    {
                        opt.PreCondition(src => IsPersonAccessAssignmentsNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonAccessAssignments.First().ManagerAccessOrganizationSetName);
                    })
                   .ForMember(dest => dest.ManagerTransferOrganizationSetName, opt =>
                    {
                        opt.PreCondition(src => IsPersonAccessAssignmentsNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonAccessAssignments.First().ManagerTransferOrganizationSetName);
                    })
                   .ForMember(dest => dest.ProfessionalTransferOrganizationSetName, opt =>
                    {
                        opt.PreCondition(src => IsPersonAccessAssignmentsNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonAccessAssignments.First().ProfessionalTransferOrganizationSetName);
                    })

                   .ForMember(dest => dest.LogonProfileName, opt =>
                    {
                        opt.PreCondition(src => IsUserAccountNotNull(src));
                        opt.MapFrom(src => src.UserData.User.UserAccountData.UserAccount.LogonProfileName);
                    })
                   .ForMember(dest => dest.UserName, opt =>
                    {
                        opt.PreCondition(src => IsUserAccountNotNull(src));
                        opt.MapFrom(src => src.UserData.User.UserAccountData.UserAccount.UserName);
                    })
                   .ForMember(dest => dest.GDAPName, opt =>
                   {
                       opt.PreCondition(src => IsGDAPAssignmentsNotNull(src));
                       opt.MapFrom(src => src.GDAPAssignments.First().GDAPName);
                   })
                   .ForMember(dest => dest.GDAPRole, opt =>
                    {
                        opt.PreCondition(src => IsGDAPAssignmentsNotNull(src));
                        opt.MapFrom(src => src.GDAPAssignments.First().Role);
                    })
                   .ForMember(dest => dest.State, opt =>
                    {
                        opt.PreCondition(src => IsPostalAddressesNotNull(src));
                        opt.MapFrom(src => src.PersonInformationData.PersonInformation.PostalAddresses.First().State);
                    })
                   .ForMember(dest => dest.Licenses, opt =>
                   {
                       opt.PreCondition(src => src.PersonInformationData != null && src.PersonInformationData.PersonInformation != null);
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.PersonLicenseTypes);
                   })
                   .ForMember(dest => dest.CustomDataList, opt =>
                   {
                       opt.PreCondition(src => src.PersonInformationData != null && src.PersonInformationData.PersonInformation != null);
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.CustomDataList);
                   })
                   .ForMember(dest => dest.CustomDates, opt =>
                   {
                       opt.PreCondition(src => src.PersonInformationData != null && src.PersonInformationData.PersonInformation != null);
                       opt.MapFrom(src => src.PersonInformationData.PersonInformation.CustomDates);
                   });
        }

        private bool IsPersonNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                                             && s.PersonInformationData.PersonInformation.PersonData != null
                                             && s.PersonInformationData.PersonInformation.PersonData.Person != null;
        }

        private bool IsJobAssignmentDetailsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.JobAssignmentData != null && s.JobAssignmentData.JobAssignment != null
                                                && s.JobAssignmentData.JobAssignment.JobAssignmentDetailsData != null
                                                && s.JobAssignmentData.JobAssignment.JobAssignmentDetailsData.JobAssignmentDetails != null;
        }

        private bool IsEmploymentTermAssignmentsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.JobAssignmentData != null && s.JobAssignmentData.EmploymentTermAssignments != null && s.JobAssignmentData.EmploymentTermAssignments.Any();
        }

        private bool IsHomeAccountsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                && s.PersonInformationData.PersonInformation.HomeAccounts != null && s.PersonInformationData.PersonInformation.HomeAccounts.Any();
        }

        private bool IsEmploymentStatusListNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                && s.PersonInformationData.PersonInformation.EmploymentStatusList != null && s.PersonInformationData.PersonInformation.EmploymentStatusList.Any();
        }

        private bool IsBadgeAssignmentsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                && s.PersonInformationData.PersonInformation.BadgeAssignments != null && s.PersonInformationData.PersonInformation.BadgeAssignments.Any();
        }

        private bool IsAccessAssignmentNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                && s.PersonInformationData.PersonInformation.AccessAssignmentData != null && s.PersonInformationData.PersonInformation.AccessAssignmentData.AccessAssignment != null;
        }

        private bool IsPersonAccessAssignmentsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
                && s.PersonInformationData.PersonInformation.PersonAccessAssignments != null && s.PersonInformationData.PersonInformation.PersonAccessAssignments.Any();
        }

        private bool IsUserAccountNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.UserData != null && s.UserData.User != null
                && s.UserData.User.UserAccountData != null && s.UserData.User.UserAccountData.UserAccount != null;
        }

        private bool IsGDAPAssignmentsNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.GDAPAssignments != null && s.GDAPAssignments.Any();
        }

        private bool IsPostalAddressesNotNull(XmlApi.Contracts.Responses.Personality s)
        {
            return s.PersonInformationData != null && s.PersonInformationData.PersonInformation != null
               && s.PersonInformationData.PersonInformation.PostalAddresses != null && s.PersonInformationData.PersonInformation.PostalAddresses.Any();
        }
    }
}
