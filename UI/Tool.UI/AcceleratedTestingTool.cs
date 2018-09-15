using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Kronos.AcceleratedTool.Commands;
using Kronos.AcceleratedTool.Commands.Exceptions;
using Kronos.AcceleratedTool.DataAccess.Common;
using Kronos.AcceleratedTool.DataAccess.Common.Dapper;
using Kronos.AcceleratedTool.DataAccess.Common.DataContext;
using Kronos.AcceleratedTool.Jobs;
using Kronos.AcceleratedTool.Jobs.Exceptions;
using Kronos.AcceleratedTool.Jobs.GetEmployeesData;
using Kronos.AcceleratedTool.Jobs.GetEmployeesData.Criterias;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Criterias;
using Kronos.AcceleratedTool.Jobs.GetOvertimeTestData;
using Kronos.AcceleratedTool.Jobs.GetOvertimeTestData.Criterias;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData.Criterias;
using Kronos.AcceleratedTool.Jobs.GetShiftGuaranteeTestData;
using Kronos.AcceleratedTool.Jobs.GetShiftGuaranteeTestData.Criterias;
using Kronos.AcceleratedTool.Jobs.GetTimecardTestData;
using Kronos.AcceleratedTool.Jobs.GetTimecardTestData.Criterias;
using Kronos.AcceleratedTool.Jobs.JobStatusTracking;
using Kronos.AcceleratedTool.Jobs.Logs;
using Kronos.AcceleratedTool.License.Exceptions;
using Kronos.AcceleratedTool.UI.Resources;
using Kronos.AcceleratedTool.UI.Validation;
using Kronos.AcceleratedTool.XmlApi;
using Kronos.AcceleratedTool.XmlApi.Exceptions;
using Kronos.AcceleratedTool.XmlApi.TestLogin;
using Component = Castle.MicroKernel.Registration.Component;
using ICommandExecutor = Kronos.AcceleratedTool.Commands.ICommandExecutor;

namespace Kronos.AcceleratedTool.UI
{
    public partial class AcceleratedTestingTool : Form
    {
        private const string DateFormat = "MM/dd/yyyy";
        private readonly ICommandExecutor _commandExecutor;
        private readonly IUiValidator _validator;
        private readonly IUiMessages _uiMessages;
        private readonly JobStatusNotifier _jobStatusNotifier;
        private readonly OutputFileDictionary _outputFileDictionary;
        private readonly OutputDirectory _outputDirectory;
        private readonly ILogger _logger;

        public AcceleratedTestingTool()
        {
            _commandExecutor = Program.Container.Resolve<ICommandExecutor>();
            _validator = Program.Container.Resolve<IUiValidator>();
            _uiMessages = Program.Container.Resolve<IUiMessages>();
            _jobStatusNotifier = Program.Container.Resolve<JobStatusNotifier>();
            _outputFileDictionary = Program.Container.Resolve<OutputFileDictionary>();
            _outputDirectory = Program.Container.Resolve<OutputDirectory>();
            _logger = Program.Container.Resolve<ILogger>();
            InitializeComponent();
            SetUpForm();
        }

        private delegate void SetJobStatusLabelCallback(int step, string stepDescription, int stepsCount);
        private delegate void ShowProgressBarStatusCallback(JobStatus status);

        private void SetUpForm()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ApiUrl"]))
                tbApiServerUrl.Text = ConfigurationManager.AppSettings["ApiUrl"];
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ApiUserName"]))
                tbApiUserName.Text = ConfigurationManager.AppSettings["ApiUserName"];
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ApiPassword"]))
                tbApiPassword.Text = ConfigurationManager.AppSettings["ApiPassword"];

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DbUrl"]))
                tbDbUrl.Text = ConfigurationManager.AppSettings["DbUrl"];
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DbUserName"]))
                tbDdUserName.Text = ConfigurationManager.AppSettings["DbUserName"];
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DbPassword"]))
                tbDbPassword.Text = ConfigurationManager.AppSettings["DbPassword"];

            progressWtkTabBar.Visible = false;
            progressAccessTabBar.Visible = false;
            lbAccessTabJobStatusInfo.Text = lbAccessTabJobDescription.Text = string.Empty;
            lbWtkTabJobStatusInfo.Text = lbWtkTabJobStatusDescription.Text = string.Empty;
            _jobStatusNotifier.HandleMessage += OnHandleJobStatus;

            bJobWorker.ProgressChanged += jobWorkerProcess_ProgressChanged;
            bJobWorker.RunWorkerCompleted += jobWorkerProcess_RunWorkerCompleted;
        }

        private void SetJobStatusLabel(int step, string stepDescription, int stepsCount)
        {
            if (lbAccessTabJobDescription.InvokeRequired)
            {
                SetJobStatusLabelCallback d = new SetJobStatusLabelCallback(SetJobStatusLabel);
                Invoke(d, new object[] { step, stepDescription, stepsCount });
            }
            else
            {
                lbAccessTabJobDescription.Text = stepDescription;
            }

            if (lbWtkTabJobStatusDescription.InvokeRequired)
            {
                SetJobStatusLabelCallback d = new SetJobStatusLabelCallback(SetJobStatusLabel);
                Invoke(d, new object[] { step, stepDescription, stepsCount });
            }
            else
            {
                lbWtkTabJobStatusDescription.Text = stepDescription;
            }

            if (lbAccessTabJobStatusInfo.InvokeRequired)
            {
                SetJobStatusLabelCallback d = new SetJobStatusLabelCallback(SetJobStatusLabel);
                Invoke(d, new object[] { step, stepDescription, stepsCount });
            }
            else
            {
                if (step != default(int) && stepsCount != default(int))
                    lbAccessTabJobStatusInfo.Text = string.Format(ToolUI.JobStatusInfoFormat, step, stepsCount);
            }

            if (lbWtkTabJobStatusInfo.InvokeRequired)
            {
                SetJobStatusLabelCallback d = new SetJobStatusLabelCallback(SetJobStatusLabel);
                Invoke(d, new object[] { step, stepDescription, stepsCount });
            }
            else
            {
                if (step != default(int) && stepsCount != default(int))
                    lbWtkTabJobStatusInfo.Text = string.Format(ToolUI.JobStatusInfoFormat, step, stepsCount);
            }
        }

        private void ShowProgressBarStatus(JobStatus status)
        {
            if (progressAccessTabBar.InvokeRequired || progressWtkTabBar.InvokeRequired)
            {
                ShowProgressBarStatusCallback d = new ShowProgressBarStatusCallback(ShowProgressBarStatus);
                Invoke(d, new object[] { status });
            }
            else
            {
                switch (status)
                {
                    case JobStatus.Success:
                        progressAccessTabBar.SetDefaultStyle();
                        progressWtkTabBar.SetDefaultStyle();
                        break;
                    case JobStatus.SuccessWithWarnings:
                        progressAccessTabBar.SetWarningStyle();
                        progressWtkTabBar.SetWarningStyle();
                        break;
                    case JobStatus.Failed:
                        progressAccessTabBar.SetErrorStyle();
                        progressWtkTabBar.SetErrorStyle();
                        break;
                }
            }
        }

        private void OnHandleJobStatus(object sender, EventArgs args)
        {
            var messageEvent = args as JobStatusEventArgs;
            if (messageEvent != null)
            {
                var percentOfImplementation = messageEvent.Percent;
                bJobWorker.ReportProgress(percentOfImplementation);
                SetJobStatusLabel(messageEvent.Step, messageEvent.StepDescription, messageEvent.StepsCount);
            }
        }

        private void ExecuteJob(IJob job)
        {
            try
            {
                var jobStatus = job.Run();

                ShowProgressBarStatus(jobStatus);
                if (jobStatus == JobStatus.Failed)
                {
                    MessageBox.Show(ToolUI.MsgJobFailed);
                }

                if (jobStatus == JobStatus.SuccessWithWarnings)
                {
                    MessageBox.Show(ToolUI.MsgJobWasCompletedWithSomeWarnings);
                }
            }
            catch (DependentJobWasNotRunException)
            {
                ShowProgressBarStatus(JobStatus.Failed);
                MessageBox.Show(ToolUI.MsgEmployeeJobWaNotRun);
            }
            catch (FileNotAccessibleException ex)
            {
                ShowProgressBarStatus(JobStatus.Failed);
                MessageBox.Show(string.Format(ToolUI.MsgFileIsNotAccessible, ex.FileName));
            }
        }

        private void ExecuteJob<TCriteria>(IParameterisedJob<TCriteria> job, TCriteria criteria)
        {
            try
            {
                var jobStatus = job.Run(criteria);

                ShowProgressBarStatus(jobStatus);
                if (jobStatus == JobStatus.Failed)
                {
                    MessageBox.Show(ToolUI.MsgJobFailed);
                }

                if (jobStatus == JobStatus.SuccessWithWarnings)
                {
                    MessageBox.Show(ToolUI.MsgJobWasCompletedWithSomeWarnings);
                }
            }
            catch (DependentJobWasNotRunException)
            {
                ShowProgressBarStatus(JobStatus.Failed);
                MessageBox.Show(ToolUI.MsgEmployeeAndPayRuleJobsWereNotRun);
            }
            catch (FileNotAccessibleException ex)
            {
                ShowProgressBarStatus(JobStatus.Failed);
                MessageBox.Show(string.Format(ToolUI.MsgFileIsNotAccessible, ex.FileName));
            }
            catch (SourceFileWasNotFoundException ex)
            {
                ShowProgressBarStatus(JobStatus.Failed);
                MessageBox.Show(string.Format(ToolUI.SourceFileIsNotFoundAt, ex.FileName), ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLoginData(string url, string userName, string password, string license)
        {
            bool licenseIsValid;

            try
            {
                licenseIsValid = _validator.IsLicenseValid(license);
            }
            catch (CanNotReadDateFromLicenseFileException)
            {
                MessageBox.Show(ToolUI.ErrorMsgWrongFormatOfLicenseFile, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (LicenseDateStringInvalidFormatException)
            {
                MessageBox.Show(ToolUI.ErrorMsgWrongFormatOfLicenseFile, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (LicenseHasExpiredException)
            {
                MessageBox.Show(ToolUI.LicenseHasExpired, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!licenseIsValid)
            {
                _uiMessages.LicenseMessage();
                return false;
            }

            if (!_validator.IsUrlValid(url))
            {
                _uiMessages.UrlMessage();
                return false;
            }

            if (!_validator.IsLoginValid(userName, password))
            {
                _uiMessages.CredentialsMessage();
                return false;
            }

            return true;
        }

        private bool IsStartDateValid(string startDate)
        {
            var validationState = _validator.IsMaskedTextBoxDateStringValid(startDate);
            if (((IList)new[] { ValidatorState.FieldIsEmpty, ValidatorState.CanNotBeParsed }).Contains(validationState))
            {
                _uiMessages.InvalidStartDateMessage();
                return false;
            }

            if (validationState == ValidatorState.LessThanMinimumValue)
            {
                _uiMessages.StartDateShouldBeGreaterThanMinimumDate();
                return false;
            }

            return true;
        }

        private void SetStartDayDefaultValue()
        {
            var startDateMaskedTextBoxes = new MaskedTextBox[]
            {
                tbExceptionTestStartDate,
                mtbOvertimeTestStartDate,
                mtbTimecardTestStartDate,
                mtbShiftGuaranteeTestStartDate,
                mtbPunchRoundTestStartDate
            };

            foreach (var startDateMaskedTextBox in startDateMaskedTextBoxes)
            {
                startDateMaskedTextBox.Text = DateTime.Today.ToString(DateFormat);
            }
        }

        private bool TryLoginToApi()
        {
            try
            {
                if (ValidateLoginData(tbApiServerUrl.Text, tbApiUserName.Text, tbApiPassword.Text, tbLicenseCode.Text))
                {
                    SetUpXmlApiSettings();

                    var testApiLoginCommand =
                        new TestApiLoginCommand(Program.Container.Resolve<ITestLoginXmlApiService>());
                    var result = testApiLoginCommand.Execute();
                    if (!result)
                    {
                        ShowProgressBarStatus(JobStatus.Failed);
                        _uiMessages.TestLoginMessage(false);
                    }

                    return result;
                }

                return false;
            }
            catch (XmlApiLoginException ex)
            {
                _logger.Error(ex.Message, ex);
                ShowProgressBarStatus(JobStatus.Failed);
                _uiMessages.TestLoginMessage(false);
                return false;
            }
        }

        private void SetUpXmlApiSettings()
        {
            if (!Program.Container.Kernel.HasComponent(typeof(XmlApiSettings)))
            {
                var xmlApiSetting = new XmlApiSettings
                {
                    Url = tbApiServerUrl.Text,
                    UserName = tbApiUserName.Text,
                    Password = tbApiPassword.Text
                };
                Program.Container.Register(Component.For<XmlApiSettings>().Instance(xmlApiSetting));
            }
            else
            {
                var currentXmlApiSettings = Program.Container.Resolve<XmlApiSettings>();
                currentXmlApiSettings.Url = tbApiServerUrl.Text;
                currentXmlApiSettings.UserName = tbApiUserName.Text;
                currentXmlApiSettings.Password = tbApiPassword.Text;
            }
        }

        private void SetUpDbSettings()
        {
            if (!Program.Container.Kernel.HasComponent(typeof(DatabaseSettings)))
            {
                var dbSettings = new DatabaseSettings
                {
                    Url = tbDbUrl.Text,
                    UserName = tbDdUserName.Text,
                    Password = tbDbPassword.Text
                };
                Program.Container.Register(Component.For<DatabaseSettings>().Instance(dbSettings));
            }
            else
            {
                var currentXmlApiSettings = Program.Container.Resolve<DatabaseSettings>();
                currentXmlApiSettings.Url = tbDbUrl.Text;
                currentXmlApiSettings.UserName = tbDdUserName.Text;
                currentXmlApiSettings.Password = tbDbPassword.Text;
            }

            IDbProvider dbProvider = rbSqlProvider.Checked ? (IDbProvider)new SqlProvider() : new OracleProvider();
            if (!Program.Container.Kernel.HasComponent(typeof(IDataContext)))
            {
                var dataContext = new DapperDataContext(Program.Container.Resolve<DatabaseSettings>(), dbProvider);
                Program.Container.Register(Component.For<IDataContext>().Instance(dataContext));
            }
            else
            {
                var currentXmlApiSettings = Program.Container.Resolve<IDataContext>();
                currentXmlApiSettings.DbProvider = dbProvider;
            }
        }

        private void btnApiLogin_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bApiConnectionTest_DoWork;
            jobWorkerProcess_DoInitialWork();
            bJobWorker.RunWorkerAsync();
        }

        private void btnDbLogin_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bDbConnectionTest_DoWork;
            jobWorkerProcess_DoInitialWork();
            bJobWorker.RunWorkerAsync();
        }

        private void btnExtractDataFromDb_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bEmplyeViaDbWorker_DoWork;
            jobWorkerProcess_DoInitialWork();
            bJobWorker.RunWorkerAsync();
        }

        private void btnExceptionTestPopulate_Click(object sender, EventArgs e)
        {
            TestButton_Click(tbExceptionTestStartDate, bExceptionTestDataPopulationWorker_DoWork);
        }

        private void btnExceptionTestGather_Click(object sender, EventArgs e)
        {
            TestButton_Click(tbExceptionTestStartDate, bExceptionTestDataGatheringWorker_DoWork);
        }

        private void btnExceptionTestClean_Click(object sender, EventArgs e)
        {
            TestButton_Click(tbExceptionTestStartDate, bExceptionTestDataCleanUpWorker_DoWork);
        }

        private void btnOvertimeTestPopulate_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbOvertimeTestStartDate, bOvertimeTestDataPopulationWorker_DoWork);
        }

        private void btnOvertimeTestGather_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbOvertimeTestStartDate, bOvertimeTestDataGatheringWorker_DoWork);
        }

        private void btnOvertimeTestClean_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbOvertimeTestStartDate, bOvertimeTestDataCleanUpWorker_DoWork);
        }

        private void btnTimecardTestPopulate_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbTimecardTestStartDate, bTimecardTestDataPopulationWorker_DoWork);
        }

        private void btnTimecardTestGather_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbTimecardTestStartDate, bTimecardTestDataGatheringWorker_DoWork);
        }

        private void btnTimecardTestClean_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbTimecardTestStartDate, bTimecardTestDataCleanUpWorker_DoWork);
        }

        private void btnShiftGuaranteeTestPopulate_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbShiftGuaranteeTestStartDate, bShiftGuaranteeTestDataPopulateWorker_DoWork);
        }

        private void btnShiftGuaranteeTestGather_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbShiftGuaranteeTestStartDate, bShiftGuaranteeTestDataGatherWorker_DoWork);
        }

        private void btnShiftGuaranteeTestClean_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbShiftGuaranteeTestStartDate, bShiftGuaranteeTestDataCleanUpWorker_DoWork);
        }

        private void btnPunchRoundTestPopulate_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbPunchRoundTestStartDate, bPunchRoundTestDataPopulationWorker_DoWork);
        }

        private void btnPunchRoundTestGather_Click(object sender, EventArgs e)
        {
            SetUpDbSettings();
            TestButton_Click(mtbPunchRoundTestStartDate, bPunchRoundTestDataGatheringWorker_DoWork);
        }

        private void btnPunchRoundTestClean_Click(object sender, EventArgs e)
        {
            TestButton_Click(mtbPunchRoundTestStartDate, bPunchRoundTestDataCleanUpWorker_DoWork);
        }

        private void btnUnderTenThousandEmployees_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bEmployeeViaApiWorker_DoWork;

            if (TryLoginToApi())
            {
                jobWorkerProcess_DoInitialWork();
                bJobWorker.RunWorkerAsync();
            }
        }

        private void btnFromTenToSeventyFiveThousandEmployees_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bAllEmployeeViaApiWorker_DoWork;

            if (TryLoginToApi())
            {
                jobWorkerProcess_DoInitialWork();
                bJobWorker.RunWorkerAsync();
            }
        }

        private void btnFirstFiveHundredEmployees_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bLimitEmployeeViaApiWorker_DoWork;

            if (TryLoginToApi())
            {
                jobWorkerProcess_DoInitialWork();
                bJobWorker.RunWorkerAsync();
            }
        }

        private void jobWorkerProcess_DoInitialWork()
        {
            bJobWorker.WorkerReportsProgress = true;
            tbPgWTKTesting.Enabled = false;
            tbPgAccessSetup.Enabled = false;
            progressWtkTabBar.Visible = true;
            progressAccessTabBar.Visible = true;
        }

        private void jobWorkerProcess_RemoveAllEvenHandlers()
        {
            // clear previous job action
            // if you use the same BackgroundWorker for few jobs you have to remove all DoWork events before new DoWork event assignment
            // otherwise the worker will run all assigned events
            ShowProgressBarStatus(JobStatus.Success);
            bJobWorker.DoWork -= bExceptionTestDataPopulationWorker_DoWork;
            bJobWorker.DoWork -= bExceptionTestDataGatheringWorker_DoWork;
            bJobWorker.DoWork -= bExceptionTestDataCleanUpWorker_DoWork;
            bJobWorker.DoWork -= bEmployeeViaApiWorker_DoWork;
            bJobWorker.DoWork -= bLimitEmployeeViaApiWorker_DoWork;
            bJobWorker.DoWork -= bAllEmployeeViaApiWorker_DoWork;
            bJobWorker.DoWork -= bEmplyeViaDbWorker_DoWork;
            bJobWorker.DoWork -= bPayRuleBuildingWorker_DoWork;
            bJobWorker.DoWork -= bOvertimeTestDataPopulationWorker_DoWork;
            bJobWorker.DoWork -= bOvertimeTestDataGatheringWorker_DoWork;
            bJobWorker.DoWork -= bOvertimeTestDataCleanUpWorker_DoWork;
            bJobWorker.DoWork -= bTimecardTestDataPopulationWorker_DoWork;
            bJobWorker.DoWork -= bTimecardTestDataGatheringWorker_DoWork;
            bJobWorker.DoWork -= bTimecardTestDataCleanUpWorker_DoWork;
            bJobWorker.DoWork -= bPunchRoundTestDataPopulationWorker_DoWork;
            bJobWorker.DoWork -= bPunchRoundTestDataGatheringWorker_DoWork;
            bJobWorker.DoWork -= bPunchRoundTestDataCleanUpWorker_DoWork;
            bJobWorker.DoWork -= bDbConnectionTest_DoWork;
            bJobWorker.DoWork -= bApiConnectionTest_DoWork;
            bJobWorker.DoWork -= bShiftGuaranteeTestDataPopulateWorker_DoWork;
            bJobWorker.DoWork -= bShiftGuaranteeTestDataCleanUpWorker_DoWork;
            bJobWorker.DoWork -= bShiftGuaranteeTestDataGatherWorker_DoWork;
        }

        private void TestButton_Click(MaskedTextBox tbStartDate, DoWorkEventHandler doWork)
        {
            if (!IsStartDateValid(tbStartDate.Text))
                return;

            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += doWork;

            if (TryLoginToApi())
            {
                jobWorkerProcess_DoInitialWork();
                bJobWorker.RunWorkerAsync();
            }
        }

        private void jobWorkerProcess_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressWtkTabBar.Value = e.ProgressPercentage;
            progressAccessTabBar.Value = e.ProgressPercentage;
        }

        private void jobWorkerProcess_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            tbPgWTKTesting.Enabled = true;
            tbPgAccessSetup.Enabled = true;
            progressAccessTabBar.Visible = progressWtkTabBar.Visible = false;
            progressAccessTabBar.Value = progressWtkTabBar.Value = 0;
            lbAccessTabJobDescription.Text = lbAccessTabJobStatusInfo.Text = string.Empty;
            lbWtkTabJobStatusDescription.Text = lbWtkTabJobStatusInfo.Text = string.Empty;
        }

        private void bEmployeeViaApiWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateEmployeeViaApiJob(10000, chbTopEmployeesShowWage.Checked);
        }

        private void bAllEmployeeViaApiWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateEmployeeViaApiJob(75000, cbMegaEmployeesShowWage.Checked);
        }

        private void bLimitEmployeeViaApiWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateEmployeeViaApiJob(500, cbLimitEmployeesShowWage.Checked);
        }

        private void InitiateEmployeeViaApiJob(int employeesCount, bool showWage)
        {
            var employeesPerRequest = ConfigurationManager.AppSettings["EmployeesPerRequestForViaApiJob"] == null ? default(int) : Convert.ToInt32(ConfigurationManager.AppSettings["EmployeesPerRequestForViaApiJob"]);

            SetUpXmlApiSettings();
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            var job = new GetEmployeesViaApiJob(_commandExecutor, _outputDirectory, jobStatusTracker, _outputFileDictionary, _logger);
            var criteria = new GetEmployeeCriteria
            {
                EmployeesCount = employeesCount,
                ShowWage = showWage,
                EmployeesPerPageNumber = employeesPerRequest
            };

            ExecuteJob<GetEmployeeCriteria>(job, criteria);
        }

        private void bEmplyeViaDbWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (ValidateLoginData(tbDbUrl.Text, tbDdUserName.Text, tbDbPassword.Text, tbLicenseCode.Text))
            {
                SetUpDbSettings();
                var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
                var job = new GetEmployeesViaDbJob(_commandExecutor, _outputDirectory, jobStatusTracker, _outputFileDictionary, _logger);
                ExecuteJob(job);
            }
        }

        private void bPayRuleBuildingWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SetUpXmlApiSettings();
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            var job = new GetPayRuleBuildingDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
            ExecuteJob(job);
        }

        private void bExceptionTestDataPopulationWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateExteptionTestJob(1);
        }

        private void bExceptionTestDataGatheringWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateExteptionTestJob(2);
        }

        private void bExceptionTestDataCleanUpWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateExteptionTestJob(3);
        }

        private void InitiateExteptionTestJob(int jobNumber)
        {
            SetUpXmlApiSettings();
            IParameterisedJob<ExceptionTestCriteria> job = null;
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            switch (jobNumber)
            {
                case 1:
                    job = new PopulateExceptionTestDataJob(_commandExecutor, Program.Container.Resolve<OutputFileDictionary>(), jobStatusTracker, _logger);
                    break;
                case 2:
                    job = new GatherExceptionTestTimesheetJob(_commandExecutor, _outputFileDictionary, _outputDirectory, jobStatusTracker, _logger);
                    break;
                case 3:
                    job = new CleanUpExceptionTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
            }

            DateTime startDate;
            DateTime.TryParse(tbExceptionTestStartDate.Text, out startDate);
            var criteria = new ExceptionTestCriteria
            {
                StartDate = startDate
            };

            ExecuteJob<ExceptionTestCriteria>(job, criteria);
        }

        private void bOvertimeTestDataPopulationWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateOvertimeTestJob(1);
        }

        private void bOvertimeTestDataGatheringWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateOvertimeTestJob(2);
        }

        private void bOvertimeTestDataCleanUpWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateOvertimeTestJob(3);
        }

        private void InitiateOvertimeTestJob(int jobNumber)
        {
            SetUpXmlApiSettings();
            IParameterisedJob<OvertimeTestCriteria> job = null;
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            switch (jobNumber)
            {
                case 1:
                    job = new PopulateOvertimeTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 2:
                    job = new GatherOvertimeTestTimesheetJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 3:
                    job = new CleanUpOvertimeTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
            }

            DateTime startDate;
            DateTime.TryParse(mtbOvertimeTestStartDate.Text, out startDate);
            var criteria = new OvertimeTestCriteria
            {
                StartDate = startDate
            };

            ExecuteJob<OvertimeTestCriteria>(job, criteria);
        }

        private void bTimecardTestDataPopulationWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateTimecardTestJob(1);
        }

        private void bTimecardTestDataGatheringWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateTimecardTestJob(2);
        }

        private void bTimecardTestDataCleanUpWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateTimecardTestJob(3);
        }

        private void bShiftGuaranteeTestDataGatherWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateShiftGuaranteeTestJob(2);
        }

        private void bShiftGuaranteeTestDataCleanUpWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateShiftGuaranteeTestJob(3);
        }

        private void bShiftGuaranteeTestDataPopulateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiateShiftGuaranteeTestJob(1);
        }

        private void bDbConnectionTest_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool result = ValidateLoginData(tbDbUrl.Text, tbDdUserName.Text, tbDbPassword.Text, tbLicenseCode.Text);
            if (result)
            {
                _jobStatusNotifier.NotifyNewStep(1, ToolUI.MsgConnectionTest, 1);
                SetUpDbSettings();

                var dbDataContext = Program.Container.Resolve<IDataContext>();

                result = dbDataContext.TestConnection();
                if (!result)
                    ShowProgressBarStatus(JobStatus.Failed);

                _uiMessages.TestLoginMessage(result);
            }
        }

        private void bApiConnectionTest_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _jobStatusNotifier.NotifyNewStep(1, ToolUI.MsgConnectionTest, 1);
            var result = TryLoginToApi();

            if (result)
                _uiMessages.TestLoginMessage(true);
        }

        private void bPunchRoundTestDataPopulationWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiatePunchRoundTestJob(1);
        }

        private void bPunchRoundTestDataGatheringWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiatePunchRoundTestJob(2);
        }

        private void bPunchRoundTestDataCleanUpWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitiatePunchRoundTestJob(3);
        }

        private void InitiateTimecardTestJob(int jobNumber)
        {
            SetUpXmlApiSettings();
            IParameterisedJob<TimecardTestCriteria> job = null;
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            switch (jobNumber)
            {
                case 1:
                    job = new PopulateTimecardTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 2:
                    job = new GatherTimecardTestTimesheetJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 3:
                    job = new CleanUpTimecardTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
            }

            DateTime startDate;
            DateTime.TryParse(mtbTimecardTestStartDate.Text, out startDate);
            var criteria = new TimecardTestCriteria(startDate);
            try
            {
                ExecuteJob<TimecardTestCriteria>(job, criteria);
            }
            catch (DateOutOfRangeValidationException ex)
            {
                MessageBox.Show(string.Format(ToolUI.MsgInvalidDateRange, ex.Filename, ex.StartDate.ToString(DateFormat), ex.EndDate.ToString(DateFormat)));
            }
        }

        private void InitiatePunchRoundTestJob(int jobNumber)
        {
            SetUpXmlApiSettings();
            IParameterisedJob<PunchRoundTestCriteria> job = null;
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            switch (jobNumber)
            {
                case 1:
                    job = new PopulatePunchRoundTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 2:
                    job = new GatherPunchRoundTestTimesheetJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 3:
                    job = new CleanUpPunchRoundTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
            }

            DateTime startDate;
            DateTime.TryParse(mtbPunchRoundTestStartDate.Text, out startDate);
            var criteria = new PunchRoundTestCriteria {StartDate = startDate};
            try
            {
                ExecuteJob<PunchRoundTestCriteria>(job, criteria);
            }
            catch (DateOutOfRangeValidationException ex)
            {
                MessageBox.Show(string.Format(ToolUI.MsgInvalidDateRange, ex.Filename, ex.StartDate.ToString(DateFormat), ex.EndDate.ToString(DateFormat)));
            }
        }

        private void InitiateShiftGuaranteeTestJob(int jobNumber)
        {
            SetUpXmlApiSettings();
            IParameterisedJob<ShiftGuaranteeTestCriteria> job = null;
            var jobStatusTracker = Program.Container.Resolve<JobStatusTracker>();
            switch (jobNumber)
            {
                case 1:
                    job = new PopulateShiftGuaranteeTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 2:
                    job = new GatherShiftGuaranteeTestTimesheetJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
                case 3:
                    job = new CleanUpShiftGuaranteeTestDataJob(_commandExecutor, _outputFileDictionary, jobStatusTracker, _logger);
                    break;
            }

            DateTime startDate;
            DateTime.TryParse(mtbShiftGuaranteeTestStartDate.Text, out startDate);
            var criteria = new ShiftGuaranteeTestCriteria { StartDate = startDate };
            ExecuteJob<ShiftGuaranteeTestCriteria>(job, criteria);
        }

        private void AcceleratedTestingTool_Load(object sender, EventArgs e)
        {
            SetStartDayDefaultValue();
        }

        private void btnExtractPayRule_Click(object sender, EventArgs e)
        {
            jobWorkerProcess_RemoveAllEvenHandlers();
            bJobWorker.DoWork += bPayRuleBuildingWorker_DoWork;

            if (TryLoginToApi())
            {
                jobWorkerProcess_DoInitialWork();
                bJobWorker.RunWorkerAsync();
            }
        }

        private void tbDbUrl_MouseHover(object sender, EventArgs e)
        {
            var message = rbSqlProvider.Checked ? ToolUI.SqlUrlTip : ToolUI.OracleUrlTip;
            tootTipDbUrl.Show(string.Empty, tbDbUrl);
            tootTipDbUrl.Show(message, tbDbUrl);
        }

        private void tbDbUrl_MouseLeave(object sender, EventArgs e)
        {
            tootTipDbUrl.Hide(tbDbUrl);
        }
    }
}
