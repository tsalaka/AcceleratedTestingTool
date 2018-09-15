using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Jobs.GetEmployeesData
{
    public class EmployeeMapper
    {
        private const string ExceptionTestName = "Exception Test";
        private const string OverTimeTestName = "Overtime Test";
        private const string TimeCardTestName = "Timecard Test";
        private const string ShiftGuaranteeTestName = "Shift Guarantee Test";
        private const string PunchRoundTestName = "Punch Round Test";
        private const string OtherTestName = "Other Tests";

        public EmployeeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PayRulePre, PayRule>()
                    .ForMember(d => d.TestName, s => s.MapFrom(o => GetTestNameBySequence(o.Sequence)));
                cfg.CreateMap<Employee, PayRulePre>()
                    .ForMember(d => d.FullName, s => s.MapFrom(o => string.Format("{0}, {1}", o.LastName, o.FirstName)));
            });
        }

        public List<EmployeeLicense> MapLicense(List<Employee> data)
        {
            var employeeLicences = new List<EmployeeLicense>();
            if (data == null)
                return employeeLicences;

            foreach (var employee in data)
            {
                if (employee.Licenses == null)
                    continue;
                foreach (var license in employee.Licenses)
                {
                    var employeeLicence = new EmployeeLicense
                    {
                        Person = new PersonData
                        {
                            PersonNumber = employee.PersonNumber,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName
                        },
                        ActiveFlag = license.ActiveFlag,
                        LicenseTypeName = license.LicenseTypeName
                    };
                    employeeLicences.Add(employeeLicence);
                }
            }

            return employeeLicences;
        }

        public List<CustomData> MapCustomField(List<Employee> data)
        {
            var customeDataList = new List<CustomData>();
            if (data == null)
                return customeDataList;

            foreach (var employee in data)
            {
                if (employee.CustomDataList == null)
                    continue;
                foreach (var customData in employee.CustomDataList)
                {
                    var employeeCustomData = new CustomData
                    {
                        Person = new PersonData
                        {
                            PersonNumber = employee.PersonNumber,
                            LastName = employee.LastName,
                            FirstName = employee.FirstName
                        },
                        CustomDataTypeName = customData.CustomDataTypeName,
                        Text = customData.Text
                    };

                    customeDataList.Add(employeeCustomData);
                }
            }

            return customeDataList;
        }

        public List<CustomDate> MapCustomDate(List<Employee> data)
        {
            var customeDateList = new List<CustomDate>();
            if (data == null)
                return customeDateList;

            foreach (var employee in data)
            {
                if (employee.CustomDates == null)
                    continue;
                foreach (var customDate in employee.CustomDates)
                {
                    var employeeCustomDate = new CustomDate
                    {
                        Person = new PersonData
                        {
                            PersonNumber = employee.PersonNumber,
                            LastName = employee.LastName,
                            FirstName = employee.FirstName
                        },
                        CustomDateTypeName = customDate.CustomDateTypeName,
                        Date = customDate.Date
                    };

                    customeDateList.Add(employeeCustomDate);
                }
            }

            return customeDateList;
        }

        public List<PayRulePre> MapPayRulePre(List<Employee> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, PayRulePre>()
                    .ForMember(d => d.FullName, s => s.MapFrom(o => string.Format("{0}, {1}", o.LastName, o.FirstName)));
            });
            var payRules = Mapper.Map<List<Employee>, List<PayRulePre>>(data);
            var groupIndex = 0;
            payRules = payRules
               .OrderBy(s => s.PayRuleName).ToList();

            payRules = payRules
                .Select((s, i) =>
                {
                    if (i > 0 && !s.PayRuleName.Equals(payRules[i - 1].PayRuleName, StringComparison.OrdinalIgnoreCase))
                    {
                        groupIndex = 0;
                    }
                    groupIndex++;
                    s.Sequence = groupIndex;
                    return s;
                }).ToList();
            return payRules;
        }

        public List<PayRule> MapPayRule(List<PayRulePre> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PayRulePre, PayRule>()
                    .ForMember(d => d.TestName, s => s.MapFrom(o => GetTestNameBySequence(o.Sequence)));
            });
            var payRules = Mapper.Map<List<PayRulePre>, List<PayRule>>(data);
            return payRules;
        }

        private string GetTestNameBySequence(int sequence)
        {
            switch (sequence)
            {
                case 1:
                    return ExceptionTestName;
                case 2:
                    return OverTimeTestName;
                case 3:
                    return TimeCardTestName;
                case 4:
                    return ShiftGuaranteeTestName;
                case 5:
                    return PunchRoundTestName;
                default:
                    return OtherTestName;
            }
        }
    }
}
