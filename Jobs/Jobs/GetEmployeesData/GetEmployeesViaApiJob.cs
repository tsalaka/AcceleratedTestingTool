using System;
using System.Collections.Generic;
using System.Linq;
using AcceleratedTool.Commands;
using AcceleratedTool.Commands.Criterias;
using AcceleratedTool.Commands.Exceptions;
using AcceleratedTool.Jobs.GetEmployeesData.Criterias;
using AcceleratedTool.Jobs.JobStatusTracking;
using AcceleratedTool.Jobs.Resources;
using AcceleratedTool.Models.Employees;
using Employee = AcceleratedTool.Models.Employees.Employee;
using ILogger = AcceleratedTool.Jobs.Logs.ILogger;

namespace AcceleratedTool.Jobs.GetEmployeesData
{
    public class GetEmployeesViaApiJob : IParameterisedJob<GetEmployeeCriteria>
    {
        private const int IncludedForTestingPayRuleCount = 10;
        private const int DefaultEmployeesPerPageNumber = 5000;
        private const string EmployeeListFileName = "EmployeeList.csv";
        private const string EmployeeListLicenseFileName = "EmployeeListLicense.csv";
        private const string EmployeeListCustomFields = "EmployeeListCustomFields.csv";
        private const string EmployeeListCustomDateFileName = "EmployeeListCustomDate.csv";
        private readonly ICommandExecutor _commandExecutor;
        private readonly OutputDirectory _outputDirectory;
        private readonly OutputFileDictionary _outputFileDictionary;
        private readonly JobStatusTracker _statusTracker;
        private readonly ILogger _logger;

        public GetEmployeesViaApiJob(ICommandExecutor commandExecutor, OutputDirectory outputDirectory, JobStatusTracker statusTracker, OutputFileDictionary outputFileDictionary, ILogger logger)
        {
            _commandExecutor = commandExecutor;
            _outputDirectory = outputDirectory;
            _statusTracker = statusTracker;
            _outputFileDictionary = outputFileDictionary;
            _logger = logger;
        }

        public JobStatus Run(GetEmployeeCriteria criteria)
        {
            try
            {
                var hyperFindQuery = new HyperFindQuery
                {
                    HyperFindQueryName = "All Home",
                    VisibilityCode = "Public",
                    QueryDateStart = DateTime.Now,
                    QueryDateEnd = DateTime.Now
                };

                _statusTracker.ShowInitialStep(JobStepDescription.GetEmployeeNumbers);
                _logger.Info(JobStepDescription.GetEmployeeNumbers);
                var fullPersonNumbersData =
                    _commandExecutor.Execute<HyperFindQuery, List<HyperFindResult>>(hyperFindQuery);

                // if EmployeesCount is a number employees person numbers we want to get
                // if EmployeesCount is 0 - all employees
                var personNumbers = criteria.EmployeesCount == 0
                    ? fullPersonNumbersData
                    : fullPersonNumbersData.Take(criteria.EmployeesCount).ToList();

                List<Employee> fullEmployeesData = new List<Employee>();

                // read full employee data passing a portion of pers numbers
                int portion = criteria.EmployeesPerPageNumber == default(int)
                    ? DefaultEmployeesPerPageNumber
                    : criteria.EmployeesPerPageNumber;

                int pageCount = Convert.ToInt32(Math.Ceiling((double)personNumbers.Count / portion));
                var stepsCount = pageCount + 7;
                _statusTracker.Initialize(stepsCount);

                for (int i = 0; i < pageCount; i++)
                {
                    string stepDescription;
                    if (i == 0)
                    {
                        stepDescription = string.Format(JobStepDescription.GetFirstBunchOfFullEmployeeData, criteria.EmployeesCount < portion ? criteria.EmployeesCount : portion);
                    }
                    else
                    {
                        stepDescription = string.Format(JobStepDescription.GetNextBunchOfFullEmployeeData, portion);
                    }

                    _statusTracker.NotifyNewStep(stepDescription);
                    _logger.Info(stepDescription);
                    var personNumberPortion = personNumbers.Skip(i * portion).Take(portion).ToList();
                    var employeesPortion =
                        _commandExecutor.Execute<List<HyperFindResult>, List<Employee>>(personNumberPortion);

                    fullEmployeesData.AddRange(employeesPortion);
                }

                _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, EmployeeListFileName));
                _logger.Info(string.Format(JobStepDescription.ExportFile, EmployeeListFileName));
                EmployeeListStep(fullEmployeesData, criteria.ShowWage, EmployeeListFileName);

                _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, EmployeeListLicenseFileName));
                EmployeeLicenseStep(fullEmployeesData, EmployeeListLicenseFileName);

                _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, EmployeeListCustomFields));
                EmployeeCustomFieldStep(fullEmployeesData, EmployeeListCustomFields);

                _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, EmployeeListCustomDateFileName));
                EmployeeCustomDateStep(fullEmployeesData, EmployeeListCustomDateFileName);

                EmployeePayRuleStep(fullEmployeesData);

                return JobStatus.Success;
            }
            catch (FileNotAccessibleException ex)
            {
                _logger.Error(ex, GetType().Name);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, GetType().Name);
                return JobStatus.Failed;
            }
        }

        private void EmployeeListStep(List<Employee> fullData, bool showWage, string fileName)
        {
            var employees = fullData
                .Select(s =>
                {
                    if (!showWage)
                        s.BaseWageHourly = null;
                    return s;
                })
                .ToList();

            var employeeExportData = new ExportData<Employee>
            {
                DataList = employees,
                FilePath = _outputDirectory.ExcelFilePath(fileName)
            };
            _commandExecutor.Execute(employeeExportData);
        }

        private void EmployeeLicenseStep(List<Employee> fullData, string fileName)
        {
            var employeeMapper = new EmployeeMapper();
            var employeeLicenses = employeeMapper.MapLicense(fullData);
            var employeeExportData = new ExportData<EmployeeLicense>
            {
                DataList = employeeLicenses,
                FilePath = _outputDirectory.ExcelFilePath(fileName)
            };
            _commandExecutor.Execute(employeeExportData);
        }

        private void EmployeeCustomFieldStep(List<Employee> fullData, string fileName)
        {
            var employeeMapper = new EmployeeMapper();
            var customFieldsContent = employeeMapper.MapCustomField(fullData);
            var employeeExportData = new ExportData<CustomData>()
            {
                DataList = customFieldsContent,
                FilePath = _outputDirectory.ExcelFilePath(fileName)
            };

            _commandExecutor.Execute(employeeExportData);
        }

        private void EmployeeCustomDateStep(List<Employee> fullData, string fileName)
        {
            var employeeMapper = new EmployeeMapper();
            var employeeCustomDates = employeeMapper.MapCustomDate(fullData);
            var employeeExportData = new ExportData<CustomDate>
            {
                DataList = employeeCustomDates,
                FilePath = _outputDirectory.ExcelFilePath(fileName)
            };
            _commandExecutor.Execute(employeeExportData);
        }

        private void EmployeePayRuleStep(List<Employee> fullData)
        {
            var employeeMapper = new EmployeeMapper();
            var payRules = employeeMapper.MapPayRulePre(fullData);

            var excludedToTestPayRules = payRules.Where(s => s.Sequence > IncludedForTestingPayRuleCount);

            var excludedForTestingExportData = new ExportData<PayRulePre>
            {
                DataList = excludedToTestPayRules.ToList(),
                FilePath = _outputFileDictionary.OneEePerPayRuleExtra.FilePath,
                SheetName = _outputFileDictionary.OneEePerPayRuleExtra.SheetName
            };

            _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, _outputFileDictionary.OneEePerPayRuleExtra.FileName));
            _commandExecutor.Execute(excludedForTestingExportData);

            var includedToTestExportData = new ExportData<PayRule>
            {
                DataList =
                    employeeMapper.MapPayRule(payRules.Where(s => s.Sequence <= IncludedForTestingPayRuleCount).ToList()),
                FilePath = _outputFileDictionary.OneEePerPayRule.FilePath,
                SheetName = _outputFileDictionary.OneEePerPayRule.SheetName
            };

            _statusTracker.NotifyNewStep(string.Format(JobStepDescription.ExportFile, _outputFileDictionary.OneEePerPayRule.FileName));
            _commandExecutor.Execute<ExportData<PayRule>>(includedToTestExportData);
        }
    }
}