using System;
using Kronos.AcceleratedTool.UI.Resources;

namespace Kronos.AcceleratedTool.UI
{
    partial class AcceleratedTestingTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcceleratedTestingTool));
            this.tbPgWTKTesting = new System.Windows.Forms.TabPage();
            this.lbWtkTabJobStatusDescription = new System.Windows.Forms.Label();
            this.lbWtkTabJobStatusInfo = new System.Windows.Forms.Label();
            this.mtbPunchRoundTestStartDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbShiftGuaranteeTestStartDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbTimecardTestStartDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbOvertimeTestStartDate = new System.Windows.Forms.MaskedTextBox();
            this.tbExceptionTestStartDate = new System.Windows.Forms.MaskedTextBox();
            this.btnPunchRoundTestGather = new System.Windows.Forms.Button();
            this.btnPunchRoundTestClean = new System.Windows.Forms.Button();
            this.btnExceptionTestGather = new System.Windows.Forms.Button();
            this.btnPunchRoundTestPopulate = new System.Windows.Forms.Button();
            this.btnExceptionTestClean = new System.Windows.Forms.Button();
            this.lbPunchRoundTest = new System.Windows.Forms.Label();
            this.btnExceptionTestPopulate = new System.Windows.Forms.Button();
            this.lbExceptionTest = new System.Windows.Forms.Label();
            this.lbPunchRoundTestStartDate = new System.Windows.Forms.Label();
            this.lbExceptionTestStartDate = new System.Windows.Forms.Label();
            this.btnOvertimeTestGather = new System.Windows.Forms.Button();
            this.btnOvertimeTestClean = new System.Windows.Forms.Button();
            this.btnOvertimeTestPopulate = new System.Windows.Forms.Button();
            this.lbOvertimeTest = new System.Windows.Forms.Label();
            this.lbOvertimeTestStartDate = new System.Windows.Forms.Label();
            this.btnTimecardTestGather = new System.Windows.Forms.Button();
            this.btnTimecardTestClean = new System.Windows.Forms.Button();
            this.btnTimecardTestPopulate = new System.Windows.Forms.Button();
            this.lbTimecardTest = new System.Windows.Forms.Label();
            this.lbTimecardTestStartDate = new System.Windows.Forms.Label();
            this.btnShiftGuaranteeTestGather = new System.Windows.Forms.Button();
            this.btnShiftGuaranteeTestClean = new System.Windows.Forms.Button();
            this.btnShiftGuaranteeTestPopulate = new System.Windows.Forms.Button();
            this.lbShiftGuaranteeTest = new System.Windows.Forms.Label();
            this.lbShiftGuaranteeTestStartDate = new System.Windows.Forms.Label();
            this.btnExtractPayRule = new System.Windows.Forms.Button();
            this.tbPgAccessSetup = new System.Windows.Forms.TabPage();
            this.lbLargeEmployeesInfo = new System.Windows.Forms.Label();
            this.pDbProvider = new System.Windows.Forms.Panel();
            this.rbOracleProvider = new System.Windows.Forms.RadioButton();
            this.rbSqlProvider = new System.Windows.Forms.RadioButton();
            this.lbDbProvider = new System.Windows.Forms.Label();
            this.lbAccessTabJobStatusInfo = new System.Windows.Forms.Label();
            this.lbAccessTabJobDescription = new System.Windows.Forms.Label();
            this.lbLicenseCode = new System.Windows.Forms.Label();
            this.tbLicenseCode = new System.Windows.Forms.TextBox();
            this.btnExtractDataFromDb = new System.Windows.Forms.Button();
            this.lbFirstFiveHundredEmployees = new System.Windows.Forms.Label();
            this.cbLimitEmployeesShowWage = new System.Windows.Forms.CheckBox();
            this.btnFirstFiveHundredEmployees = new System.Windows.Forms.Button();
            this.lbFromTenToSeventyFiveThousandEmployees = new System.Windows.Forms.Label();
            this.cbMegaEmployeesShowWage = new System.Windows.Forms.CheckBox();
            this.btnFromTenToSeventyFiveThousandEmployees = new System.Windows.Forms.Button();
            this.lbUnderTenThousandEmployees = new System.Windows.Forms.Label();
            this.chbTopEmployeesShowWage = new System.Windows.Forms.CheckBox();
            this.btnUnderTenThousandEmployees = new System.Windows.Forms.Button();
            this.lbJdbcUrl = new System.Windows.Forms.Label();
            this.tbDbUrl = new System.Windows.Forms.TextBox();
            this.tbDdUserName = new System.Windows.Forms.TextBox();
            this.tbDbPassword = new System.Windows.Forms.TextBox();
            this.btnDbLogin = new System.Windows.Forms.Button();
            this.lbDbPassword = new System.Windows.Forms.Label();
            this.lbDdUsername = new System.Windows.Forms.Label();
            this.lbApiServerUrl = new System.Windows.Forms.Label();
            this.tbApiServerUrl = new System.Windows.Forms.TextBox();
            this.tbApiUserName = new System.Windows.Forms.TextBox();
            this.tbApiPassword = new System.Windows.Forms.TextBox();
            this.btnApiLogin = new System.Windows.Forms.Button();
            this.lbApiPassworda = new System.Windows.Forms.Label();
            this.lbApiUserName = new System.Windows.Forms.Label();
            this.tbCtrlAcceleratedTestingTool = new System.Windows.Forms.TabControl();
            this.bJobWorker = new System.ComponentModel.BackgroundWorker();
            this.tootTipDbUrl = new System.Windows.Forms.ToolTip(this.components);
            this.progressAccessTabBar = new Kronos.AcceleratedTool.UI.ColorfulProgressBar();
            this.progressWtkTabBar = new Kronos.AcceleratedTool.UI.ColorfulProgressBar();
            this.tbPgWTKTesting.SuspendLayout();
            this.tbPgAccessSetup.SuspendLayout();
            this.pDbProvider.SuspendLayout();
            this.tbCtrlAcceleratedTestingTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPgWTKTesting
            // 
            resources.ApplyResources(this.tbPgWTKTesting, "tbPgWTKTesting");
            this.tbPgWTKTesting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbPgWTKTesting.Controls.Add(this.lbWtkTabJobStatusDescription);
            this.tbPgWTKTesting.Controls.Add(this.lbWtkTabJobStatusInfo);
            this.tbPgWTKTesting.Controls.Add(this.mtbPunchRoundTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.mtbShiftGuaranteeTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.mtbTimecardTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.mtbOvertimeTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.tbExceptionTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.btnPunchRoundTestGather);
            this.tbPgWTKTesting.Controls.Add(this.btnPunchRoundTestClean);
            this.tbPgWTKTesting.Controls.Add(this.btnExceptionTestGather);
            this.tbPgWTKTesting.Controls.Add(this.btnPunchRoundTestPopulate);
            this.tbPgWTKTesting.Controls.Add(this.btnExceptionTestClean);
            this.tbPgWTKTesting.Controls.Add(this.lbPunchRoundTest);
            this.tbPgWTKTesting.Controls.Add(this.btnExceptionTestPopulate);
            this.tbPgWTKTesting.Controls.Add(this.lbExceptionTest);
            this.tbPgWTKTesting.Controls.Add(this.lbPunchRoundTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.lbExceptionTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.btnOvertimeTestGather);
            this.tbPgWTKTesting.Controls.Add(this.btnOvertimeTestClean);
            this.tbPgWTKTesting.Controls.Add(this.btnOvertimeTestPopulate);
            this.tbPgWTKTesting.Controls.Add(this.lbOvertimeTest);
            this.tbPgWTKTesting.Controls.Add(this.lbOvertimeTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.btnTimecardTestGather);
            this.tbPgWTKTesting.Controls.Add(this.btnTimecardTestClean);
            this.tbPgWTKTesting.Controls.Add(this.btnTimecardTestPopulate);
            this.tbPgWTKTesting.Controls.Add(this.lbTimecardTest);
            this.tbPgWTKTesting.Controls.Add(this.lbTimecardTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.btnShiftGuaranteeTestGather);
            this.tbPgWTKTesting.Controls.Add(this.btnShiftGuaranteeTestClean);
            this.tbPgWTKTesting.Controls.Add(this.btnShiftGuaranteeTestPopulate);
            this.tbPgWTKTesting.Controls.Add(this.lbShiftGuaranteeTest);
            this.tbPgWTKTesting.Controls.Add(this.lbShiftGuaranteeTestStartDate);
            this.tbPgWTKTesting.Controls.Add(this.btnExtractPayRule);
            this.tbPgWTKTesting.Controls.Add(this.progressWtkTabBar);
            this.tbPgWTKTesting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbPgWTKTesting.Name = "tbPgWTKTesting";
            this.tootTipDbUrl.SetToolTip(this.tbPgWTKTesting, resources.GetString("tbPgWTKTesting.ToolTip"));
            // 
            // lbWtkTabJobStatusDescription
            // 
            resources.ApplyResources(this.lbWtkTabJobStatusDescription, "lbWtkTabJobStatusDescription");
            this.lbWtkTabJobStatusDescription.Name = "lbWtkTabJobStatusDescription";
            this.tootTipDbUrl.SetToolTip(this.lbWtkTabJobStatusDescription, resources.GetString("lbWtkTabJobStatusDescription.ToolTip"));
            // 
            // lbWtkTabJobStatusInfo
            // 
            resources.ApplyResources(this.lbWtkTabJobStatusInfo, "lbWtkTabJobStatusInfo");
            this.lbWtkTabJobStatusInfo.Name = "lbWtkTabJobStatusInfo";
            this.tootTipDbUrl.SetToolTip(this.lbWtkTabJobStatusInfo, resources.GetString("lbWtkTabJobStatusInfo.ToolTip"));
            // 
            // mtbPunchRoundTestStartDate
            // 
            resources.ApplyResources(this.mtbPunchRoundTestStartDate, "mtbPunchRoundTestStartDate");
            this.mtbPunchRoundTestStartDate.Name = "mtbPunchRoundTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.mtbPunchRoundTestStartDate, resources.GetString("mtbPunchRoundTestStartDate.ToolTip"));
            // 
            // mtbShiftGuaranteeTestStartDate
            // 
            resources.ApplyResources(this.mtbShiftGuaranteeTestStartDate, "mtbShiftGuaranteeTestStartDate");
            this.mtbShiftGuaranteeTestStartDate.Name = "mtbShiftGuaranteeTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.mtbShiftGuaranteeTestStartDate, resources.GetString("mtbShiftGuaranteeTestStartDate.ToolTip"));
            // 
            // mtbTimecardTestStartDate
            // 
            resources.ApplyResources(this.mtbTimecardTestStartDate, "mtbTimecardTestStartDate");
            this.mtbTimecardTestStartDate.Name = "mtbTimecardTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.mtbTimecardTestStartDate, resources.GetString("mtbTimecardTestStartDate.ToolTip"));
            // 
            // mtbOvertimeTestStartDate
            // 
            resources.ApplyResources(this.mtbOvertimeTestStartDate, "mtbOvertimeTestStartDate");
            this.mtbOvertimeTestStartDate.Name = "mtbOvertimeTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.mtbOvertimeTestStartDate, resources.GetString("mtbOvertimeTestStartDate.ToolTip"));
            // 
            // tbExceptionTestStartDate
            // 
            resources.ApplyResources(this.tbExceptionTestStartDate, "tbExceptionTestStartDate");
            this.tbExceptionTestStartDate.Name = "tbExceptionTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.tbExceptionTestStartDate, resources.GetString("tbExceptionTestStartDate.ToolTip"));
            // 
            // btnPunchRoundTestGather
            // 
            resources.ApplyResources(this.btnPunchRoundTestGather, "btnPunchRoundTestGather");
            this.btnPunchRoundTestGather.Name = "btnPunchRoundTestGather";
            this.tootTipDbUrl.SetToolTip(this.btnPunchRoundTestGather, resources.GetString("btnPunchRoundTestGather.ToolTip"));
            this.btnPunchRoundTestGather.UseVisualStyleBackColor = true;
            this.btnPunchRoundTestGather.Click += new System.EventHandler(this.btnPunchRoundTestGather_Click);
            // 
            // btnPunchRoundTestClean
            // 
            resources.ApplyResources(this.btnPunchRoundTestClean, "btnPunchRoundTestClean");
            this.btnPunchRoundTestClean.Name = "btnPunchRoundTestClean";
            this.tootTipDbUrl.SetToolTip(this.btnPunchRoundTestClean, resources.GetString("btnPunchRoundTestClean.ToolTip"));
            this.btnPunchRoundTestClean.UseVisualStyleBackColor = true;
            this.btnPunchRoundTestClean.Click += new System.EventHandler(this.btnPunchRoundTestClean_Click);
            // 
            // btnExceptionTestGather
            // 
            resources.ApplyResources(this.btnExceptionTestGather, "btnExceptionTestGather");
            this.btnExceptionTestGather.Name = "btnExceptionTestGather";
            this.tootTipDbUrl.SetToolTip(this.btnExceptionTestGather, resources.GetString("btnExceptionTestGather.ToolTip"));
            this.btnExceptionTestGather.UseVisualStyleBackColor = true;
            this.btnExceptionTestGather.Click += new System.EventHandler(this.btnExceptionTestGather_Click);
            // 
            // btnPunchRoundTestPopulate
            // 
            resources.ApplyResources(this.btnPunchRoundTestPopulate, "btnPunchRoundTestPopulate");
            this.btnPunchRoundTestPopulate.Name = "btnPunchRoundTestPopulate";
            this.tootTipDbUrl.SetToolTip(this.btnPunchRoundTestPopulate, resources.GetString("btnPunchRoundTestPopulate.ToolTip"));
            this.btnPunchRoundTestPopulate.UseVisualStyleBackColor = true;
            this.btnPunchRoundTestPopulate.Click += new System.EventHandler(this.btnPunchRoundTestPopulate_Click);
            // 
            // btnExceptionTestClean
            // 
            resources.ApplyResources(this.btnExceptionTestClean, "btnExceptionTestClean");
            this.btnExceptionTestClean.Name = "btnExceptionTestClean";
            this.tootTipDbUrl.SetToolTip(this.btnExceptionTestClean, resources.GetString("btnExceptionTestClean.ToolTip"));
            this.btnExceptionTestClean.UseVisualStyleBackColor = true;
            this.btnExceptionTestClean.Click += new System.EventHandler(this.btnExceptionTestClean_Click);
            // 
            // lbPunchRoundTest
            // 
            resources.ApplyResources(this.lbPunchRoundTest, "lbPunchRoundTest");
            this.lbPunchRoundTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPunchRoundTest.Name = "lbPunchRoundTest";
            this.tootTipDbUrl.SetToolTip(this.lbPunchRoundTest, resources.GetString("lbPunchRoundTest.ToolTip"));
            // 
            // btnExceptionTestPopulate
            // 
            resources.ApplyResources(this.btnExceptionTestPopulate, "btnExceptionTestPopulate");
            this.btnExceptionTestPopulate.Name = "btnExceptionTestPopulate";
            this.tootTipDbUrl.SetToolTip(this.btnExceptionTestPopulate, resources.GetString("btnExceptionTestPopulate.ToolTip"));
            this.btnExceptionTestPopulate.UseVisualStyleBackColor = true;
            this.btnExceptionTestPopulate.Click += new System.EventHandler(this.btnExceptionTestPopulate_Click);
            // 
            // lbExceptionTest
            // 
            resources.ApplyResources(this.lbExceptionTest, "lbExceptionTest");
            this.lbExceptionTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbExceptionTest.Name = "lbExceptionTest";
            this.tootTipDbUrl.SetToolTip(this.lbExceptionTest, resources.GetString("lbExceptionTest.ToolTip"));
            // 
            // lbPunchRoundTestStartDate
            // 
            resources.ApplyResources(this.lbPunchRoundTestStartDate, "lbPunchRoundTestStartDate");
            this.lbPunchRoundTestStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPunchRoundTestStartDate.Name = "lbPunchRoundTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.lbPunchRoundTestStartDate, resources.GetString("lbPunchRoundTestStartDate.ToolTip"));
            // 
            // lbExceptionTestStartDate
            // 
            resources.ApplyResources(this.lbExceptionTestStartDate, "lbExceptionTestStartDate");
            this.lbExceptionTestStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbExceptionTestStartDate.Name = "lbExceptionTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.lbExceptionTestStartDate, resources.GetString("lbExceptionTestStartDate.ToolTip"));
            // 
            // btnOvertimeTestGather
            // 
            resources.ApplyResources(this.btnOvertimeTestGather, "btnOvertimeTestGather");
            this.btnOvertimeTestGather.Name = "btnOvertimeTestGather";
            this.tootTipDbUrl.SetToolTip(this.btnOvertimeTestGather, resources.GetString("btnOvertimeTestGather.ToolTip"));
            this.btnOvertimeTestGather.UseVisualStyleBackColor = true;
            this.btnOvertimeTestGather.Click += new System.EventHandler(this.btnOvertimeTestGather_Click);
            // 
            // btnOvertimeTestClean
            // 
            resources.ApplyResources(this.btnOvertimeTestClean, "btnOvertimeTestClean");
            this.btnOvertimeTestClean.Name = "btnOvertimeTestClean";
            this.tootTipDbUrl.SetToolTip(this.btnOvertimeTestClean, resources.GetString("btnOvertimeTestClean.ToolTip"));
            this.btnOvertimeTestClean.UseVisualStyleBackColor = true;
            this.btnOvertimeTestClean.Click += new System.EventHandler(this.btnOvertimeTestClean_Click);
            // 
            // btnOvertimeTestPopulate
            // 
            resources.ApplyResources(this.btnOvertimeTestPopulate, "btnOvertimeTestPopulate");
            this.btnOvertimeTestPopulate.Name = "btnOvertimeTestPopulate";
            this.tootTipDbUrl.SetToolTip(this.btnOvertimeTestPopulate, resources.GetString("btnOvertimeTestPopulate.ToolTip"));
            this.btnOvertimeTestPopulate.UseVisualStyleBackColor = true;
            this.btnOvertimeTestPopulate.Click += new System.EventHandler(this.btnOvertimeTestPopulate_Click);
            // 
            // lbOvertimeTest
            // 
            resources.ApplyResources(this.lbOvertimeTest, "lbOvertimeTest");
            this.lbOvertimeTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbOvertimeTest.Name = "lbOvertimeTest";
            this.tootTipDbUrl.SetToolTip(this.lbOvertimeTest, resources.GetString("lbOvertimeTest.ToolTip"));
            // 
            // lbOvertimeTestStartDate
            // 
            resources.ApplyResources(this.lbOvertimeTestStartDate, "lbOvertimeTestStartDate");
            this.lbOvertimeTestStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbOvertimeTestStartDate.Name = "lbOvertimeTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.lbOvertimeTestStartDate, resources.GetString("lbOvertimeTestStartDate.ToolTip"));
            // 
            // btnTimecardTestGather
            // 
            resources.ApplyResources(this.btnTimecardTestGather, "btnTimecardTestGather");
            this.btnTimecardTestGather.Name = "btnTimecardTestGather";
            this.tootTipDbUrl.SetToolTip(this.btnTimecardTestGather, resources.GetString("btnTimecardTestGather.ToolTip"));
            this.btnTimecardTestGather.UseVisualStyleBackColor = true;
            this.btnTimecardTestGather.Click += new System.EventHandler(this.btnTimecardTestGather_Click);
            // 
            // btnTimecardTestClean
            // 
            resources.ApplyResources(this.btnTimecardTestClean, "btnTimecardTestClean");
            this.btnTimecardTestClean.Name = "btnTimecardTestClean";
            this.tootTipDbUrl.SetToolTip(this.btnTimecardTestClean, resources.GetString("btnTimecardTestClean.ToolTip"));
            this.btnTimecardTestClean.UseVisualStyleBackColor = true;
            this.btnTimecardTestClean.Click += new System.EventHandler(this.btnTimecardTestClean_Click);
            // 
            // btnTimecardTestPopulate
            // 
            resources.ApplyResources(this.btnTimecardTestPopulate, "btnTimecardTestPopulate");
            this.btnTimecardTestPopulate.Name = "btnTimecardTestPopulate";
            this.tootTipDbUrl.SetToolTip(this.btnTimecardTestPopulate, resources.GetString("btnTimecardTestPopulate.ToolTip"));
            this.btnTimecardTestPopulate.UseVisualStyleBackColor = true;
            this.btnTimecardTestPopulate.Click += new System.EventHandler(this.btnTimecardTestPopulate_Click);
            // 
            // lbTimecardTest
            // 
            resources.ApplyResources(this.lbTimecardTest, "lbTimecardTest");
            this.lbTimecardTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTimecardTest.Name = "lbTimecardTest";
            this.tootTipDbUrl.SetToolTip(this.lbTimecardTest, resources.GetString("lbTimecardTest.ToolTip"));
            // 
            // lbTimecardTestStartDate
            // 
            resources.ApplyResources(this.lbTimecardTestStartDate, "lbTimecardTestStartDate");
            this.lbTimecardTestStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTimecardTestStartDate.Name = "lbTimecardTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.lbTimecardTestStartDate, resources.GetString("lbTimecardTestStartDate.ToolTip"));
            // 
            // btnShiftGuaranteeTestGather
            // 
            resources.ApplyResources(this.btnShiftGuaranteeTestGather, "btnShiftGuaranteeTestGather");
            this.btnShiftGuaranteeTestGather.Name = "btnShiftGuaranteeTestGather";
            this.tootTipDbUrl.SetToolTip(this.btnShiftGuaranteeTestGather, resources.GetString("btnShiftGuaranteeTestGather.ToolTip"));
            this.btnShiftGuaranteeTestGather.UseVisualStyleBackColor = true;
            this.btnShiftGuaranteeTestGather.Click += new System.EventHandler(this.btnShiftGuaranteeTestGather_Click);
            // 
            // btnShiftGuaranteeTestClean
            // 
            resources.ApplyResources(this.btnShiftGuaranteeTestClean, "btnShiftGuaranteeTestClean");
            this.btnShiftGuaranteeTestClean.Name = "btnShiftGuaranteeTestClean";
            this.tootTipDbUrl.SetToolTip(this.btnShiftGuaranteeTestClean, resources.GetString("btnShiftGuaranteeTestClean.ToolTip"));
            this.btnShiftGuaranteeTestClean.UseVisualStyleBackColor = true;
            this.btnShiftGuaranteeTestClean.Click += new System.EventHandler(this.btnShiftGuaranteeTestClean_Click);
            // 
            // btnShiftGuaranteeTestPopulate
            // 
            resources.ApplyResources(this.btnShiftGuaranteeTestPopulate, "btnShiftGuaranteeTestPopulate");
            this.btnShiftGuaranteeTestPopulate.Name = "btnShiftGuaranteeTestPopulate";
            this.tootTipDbUrl.SetToolTip(this.btnShiftGuaranteeTestPopulate, resources.GetString("btnShiftGuaranteeTestPopulate.ToolTip"));
            this.btnShiftGuaranteeTestPopulate.UseVisualStyleBackColor = true;
            this.btnShiftGuaranteeTestPopulate.Click += new System.EventHandler(this.btnShiftGuaranteeTestPopulate_Click);
            // 
            // lbShiftGuaranteeTest
            // 
            resources.ApplyResources(this.lbShiftGuaranteeTest, "lbShiftGuaranteeTest");
            this.lbShiftGuaranteeTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbShiftGuaranteeTest.Name = "lbShiftGuaranteeTest";
            this.tootTipDbUrl.SetToolTip(this.lbShiftGuaranteeTest, resources.GetString("lbShiftGuaranteeTest.ToolTip"));
            // 
            // lbShiftGuaranteeTestStartDate
            // 
            resources.ApplyResources(this.lbShiftGuaranteeTestStartDate, "lbShiftGuaranteeTestStartDate");
            this.lbShiftGuaranteeTestStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbShiftGuaranteeTestStartDate.Name = "lbShiftGuaranteeTestStartDate";
            this.tootTipDbUrl.SetToolTip(this.lbShiftGuaranteeTestStartDate, resources.GetString("lbShiftGuaranteeTestStartDate.ToolTip"));
            // 
            // btnExtractPayRule
            // 
            resources.ApplyResources(this.btnExtractPayRule, "btnExtractPayRule");
            this.btnExtractPayRule.Name = "btnExtractPayRule";
            this.tootTipDbUrl.SetToolTip(this.btnExtractPayRule, resources.GetString("btnExtractPayRule.ToolTip"));
            this.btnExtractPayRule.UseVisualStyleBackColor = true;
            this.btnExtractPayRule.Click += new System.EventHandler(this.btnExtractPayRule_Click);
            // 
            // tbPgAccessSetup
            // 
            resources.ApplyResources(this.tbPgAccessSetup, "tbPgAccessSetup");
            this.tbPgAccessSetup.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbPgAccessSetup.Controls.Add(this.lbLargeEmployeesInfo);
            this.tbPgAccessSetup.Controls.Add(this.pDbProvider);
            this.tbPgAccessSetup.Controls.Add(this.lbAccessTabJobStatusInfo);
            this.tbPgAccessSetup.Controls.Add(this.lbAccessTabJobDescription);
            this.tbPgAccessSetup.Controls.Add(this.progressAccessTabBar);
            this.tbPgAccessSetup.Controls.Add(this.lbLicenseCode);
            this.tbPgAccessSetup.Controls.Add(this.tbLicenseCode);
            this.tbPgAccessSetup.Controls.Add(this.btnExtractDataFromDb);
            this.tbPgAccessSetup.Controls.Add(this.lbFirstFiveHundredEmployees);
            this.tbPgAccessSetup.Controls.Add(this.cbLimitEmployeesShowWage);
            this.tbPgAccessSetup.Controls.Add(this.btnFirstFiveHundredEmployees);
            this.tbPgAccessSetup.Controls.Add(this.lbFromTenToSeventyFiveThousandEmployees);
            this.tbPgAccessSetup.Controls.Add(this.cbMegaEmployeesShowWage);
            this.tbPgAccessSetup.Controls.Add(this.btnFromTenToSeventyFiveThousandEmployees);
            this.tbPgAccessSetup.Controls.Add(this.lbUnderTenThousandEmployees);
            this.tbPgAccessSetup.Controls.Add(this.chbTopEmployeesShowWage);
            this.tbPgAccessSetup.Controls.Add(this.btnUnderTenThousandEmployees);
            this.tbPgAccessSetup.Controls.Add(this.lbJdbcUrl);
            this.tbPgAccessSetup.Controls.Add(this.tbDbUrl);
            this.tbPgAccessSetup.Controls.Add(this.tbDdUserName);
            this.tbPgAccessSetup.Controls.Add(this.tbDbPassword);
            this.tbPgAccessSetup.Controls.Add(this.btnDbLogin);
            this.tbPgAccessSetup.Controls.Add(this.lbDbPassword);
            this.tbPgAccessSetup.Controls.Add(this.lbDdUsername);
            this.tbPgAccessSetup.Controls.Add(this.lbApiServerUrl);
            this.tbPgAccessSetup.Controls.Add(this.tbApiServerUrl);
            this.tbPgAccessSetup.Controls.Add(this.tbApiUserName);
            this.tbPgAccessSetup.Controls.Add(this.tbApiPassword);
            this.tbPgAccessSetup.Controls.Add(this.btnApiLogin);
            this.tbPgAccessSetup.Controls.Add(this.lbApiPassworda);
            this.tbPgAccessSetup.Controls.Add(this.lbApiUserName);
            this.tbPgAccessSetup.Name = "tbPgAccessSetup";
            this.tootTipDbUrl.SetToolTip(this.tbPgAccessSetup, resources.GetString("tbPgAccessSetup.ToolTip"));
            // 
            // lbLargeEmployeesInfo
            // 
            resources.ApplyResources(this.lbLargeEmployeesInfo, "lbLargeEmployeesInfo");
            this.lbLargeEmployeesInfo.Name = "lbLargeEmployeesInfo";
            this.tootTipDbUrl.SetToolTip(this.lbLargeEmployeesInfo, resources.GetString("lbLargeEmployeesInfo.ToolTip"));
            // 
            // pDbProvider
            // 
            resources.ApplyResources(this.pDbProvider, "pDbProvider");
            this.pDbProvider.Controls.Add(this.rbOracleProvider);
            this.pDbProvider.Controls.Add(this.rbSqlProvider);
            this.pDbProvider.Controls.Add(this.lbDbProvider);
            this.pDbProvider.Name = "pDbProvider";
            this.tootTipDbUrl.SetToolTip(this.pDbProvider, resources.GetString("pDbProvider.ToolTip"));
            // 
            // rbOracleProvider
            // 
            resources.ApplyResources(this.rbOracleProvider, "rbOracleProvider");
            this.rbOracleProvider.Name = "rbOracleProvider";
            this.tootTipDbUrl.SetToolTip(this.rbOracleProvider, resources.GetString("rbOracleProvider.ToolTip"));
            this.rbOracleProvider.UseVisualStyleBackColor = true;
            // 
            // rbSqlProvider
            // 
            resources.ApplyResources(this.rbSqlProvider, "rbSqlProvider");
            this.rbSqlProvider.Checked = true;
            this.rbSqlProvider.Name = "rbSqlProvider";
            this.rbSqlProvider.TabStop = true;
            this.tootTipDbUrl.SetToolTip(this.rbSqlProvider, resources.GetString("rbSqlProvider.ToolTip"));
            this.rbSqlProvider.UseVisualStyleBackColor = true;
            // 
            // lbDbProvider
            // 
            resources.ApplyResources(this.lbDbProvider, "lbDbProvider");
            this.lbDbProvider.Name = "lbDbProvider";
            this.tootTipDbUrl.SetToolTip(this.lbDbProvider, resources.GetString("lbDbProvider.ToolTip"));
            // 
            // lbAccessTabJobStatusInfo
            // 
            resources.ApplyResources(this.lbAccessTabJobStatusInfo, "lbAccessTabJobStatusInfo");
            this.lbAccessTabJobStatusInfo.Name = "lbAccessTabJobStatusInfo";
            this.tootTipDbUrl.SetToolTip(this.lbAccessTabJobStatusInfo, resources.GetString("lbAccessTabJobStatusInfo.ToolTip"));
            // 
            // lbAccessTabJobDescription
            // 
            resources.ApplyResources(this.lbAccessTabJobDescription, "lbAccessTabJobDescription");
            this.lbAccessTabJobDescription.Name = "lbAccessTabJobDescription";
            this.tootTipDbUrl.SetToolTip(this.lbAccessTabJobDescription, resources.GetString("lbAccessTabJobDescription.ToolTip"));
            // 
            // lbLicenseCode
            // 
            resources.ApplyResources(this.lbLicenseCode, "lbLicenseCode");
            this.lbLicenseCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbLicenseCode.Name = "lbLicenseCode";
            this.tootTipDbUrl.SetToolTip(this.lbLicenseCode, resources.GetString("lbLicenseCode.ToolTip"));
            // 
            // tbLicenseCode
            // 
            resources.ApplyResources(this.tbLicenseCode, "tbLicenseCode");
            this.tbLicenseCode.Name = "tbLicenseCode";
            this.tootTipDbUrl.SetToolTip(this.tbLicenseCode, resources.GetString("tbLicenseCode.ToolTip"));
            // 
            // btnExtractDataFromDb
            // 
            resources.ApplyResources(this.btnExtractDataFromDb, "btnExtractDataFromDb");
            this.btnExtractDataFromDb.Name = "btnExtractDataFromDb";
            this.tootTipDbUrl.SetToolTip(this.btnExtractDataFromDb, resources.GetString("btnExtractDataFromDb.ToolTip"));
            this.btnExtractDataFromDb.UseVisualStyleBackColor = true;
            this.btnExtractDataFromDb.Click += new System.EventHandler(this.btnExtractDataFromDb_Click);
            // 
            // lbFirstFiveHundredEmployees
            // 
            resources.ApplyResources(this.lbFirstFiveHundredEmployees, "lbFirstFiveHundredEmployees");
            this.lbFirstFiveHundredEmployees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbFirstFiveHundredEmployees.Name = "lbFirstFiveHundredEmployees";
            this.tootTipDbUrl.SetToolTip(this.lbFirstFiveHundredEmployees, resources.GetString("lbFirstFiveHundredEmployees.ToolTip"));
            // 
            // cbLimitEmployeesShowWage
            // 
            resources.ApplyResources(this.cbLimitEmployeesShowWage, "cbLimitEmployeesShowWage");
            this.cbLimitEmployeesShowWage.BackColor = System.Drawing.Color.Transparent;
            this.cbLimitEmployeesShowWage.Name = "cbLimitEmployeesShowWage";
            this.tootTipDbUrl.SetToolTip(this.cbLimitEmployeesShowWage, resources.GetString("cbLimitEmployeesShowWage.ToolTip"));
            this.cbLimitEmployeesShowWage.UseVisualStyleBackColor = false;
            // 
            // btnFirstFiveHundredEmployees
            // 
            resources.ApplyResources(this.btnFirstFiveHundredEmployees, "btnFirstFiveHundredEmployees");
            this.btnFirstFiveHundredEmployees.Name = "btnFirstFiveHundredEmployees";
            this.tootTipDbUrl.SetToolTip(this.btnFirstFiveHundredEmployees, resources.GetString("btnFirstFiveHundredEmployees.ToolTip"));
            this.btnFirstFiveHundredEmployees.UseVisualStyleBackColor = true;
            this.btnFirstFiveHundredEmployees.Click += new System.EventHandler(this.btnFirstFiveHundredEmployees_Click);
            // 
            // lbFromTenToSeventyFiveThousandEmployees
            // 
            resources.ApplyResources(this.lbFromTenToSeventyFiveThousandEmployees, "lbFromTenToSeventyFiveThousandEmployees");
            this.lbFromTenToSeventyFiveThousandEmployees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbFromTenToSeventyFiveThousandEmployees.Name = "lbFromTenToSeventyFiveThousandEmployees";
            this.tootTipDbUrl.SetToolTip(this.lbFromTenToSeventyFiveThousandEmployees, resources.GetString("lbFromTenToSeventyFiveThousandEmployees.ToolTip"));
            // 
            // cbMegaEmployeesShowWage
            // 
            resources.ApplyResources(this.cbMegaEmployeesShowWage, "cbMegaEmployeesShowWage");
            this.cbMegaEmployeesShowWage.BackColor = System.Drawing.Color.Transparent;
            this.cbMegaEmployeesShowWage.Name = "cbMegaEmployeesShowWage";
            this.tootTipDbUrl.SetToolTip(this.cbMegaEmployeesShowWage, resources.GetString("cbMegaEmployeesShowWage.ToolTip"));
            this.cbMegaEmployeesShowWage.UseVisualStyleBackColor = false;
            // 
            // btnFromTenToSeventyFiveThousandEmployees
            // 
            resources.ApplyResources(this.btnFromTenToSeventyFiveThousandEmployees, "btnFromTenToSeventyFiveThousandEmployees");
            this.btnFromTenToSeventyFiveThousandEmployees.Name = "btnFromTenToSeventyFiveThousandEmployees";
            this.tootTipDbUrl.SetToolTip(this.btnFromTenToSeventyFiveThousandEmployees, resources.GetString("btnFromTenToSeventyFiveThousandEmployees.ToolTip"));
            this.btnFromTenToSeventyFiveThousandEmployees.UseVisualStyleBackColor = true;
            this.btnFromTenToSeventyFiveThousandEmployees.Click += new System.EventHandler(this.btnFromTenToSeventyFiveThousandEmployees_Click);
            // 
            // lbUnderTenThousandEmployees
            // 
            resources.ApplyResources(this.lbUnderTenThousandEmployees, "lbUnderTenThousandEmployees");
            this.lbUnderTenThousandEmployees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbUnderTenThousandEmployees.Name = "lbUnderTenThousandEmployees";
            this.tootTipDbUrl.SetToolTip(this.lbUnderTenThousandEmployees, resources.GetString("lbUnderTenThousandEmployees.ToolTip"));
            // 
            // chbTopEmployeesShowWage
            // 
            resources.ApplyResources(this.chbTopEmployeesShowWage, "chbTopEmployeesShowWage");
            this.chbTopEmployeesShowWage.BackColor = System.Drawing.Color.Transparent;
            this.chbTopEmployeesShowWage.Name = "chbTopEmployeesShowWage";
            this.tootTipDbUrl.SetToolTip(this.chbTopEmployeesShowWage, resources.GetString("chbTopEmployeesShowWage.ToolTip"));
            this.chbTopEmployeesShowWage.UseVisualStyleBackColor = false;
            // 
            // btnUnderTenThousandEmployees
            // 
            resources.ApplyResources(this.btnUnderTenThousandEmployees, "btnUnderTenThousandEmployees");
            this.btnUnderTenThousandEmployees.Name = "btnUnderTenThousandEmployees";
            this.tootTipDbUrl.SetToolTip(this.btnUnderTenThousandEmployees, resources.GetString("btnUnderTenThousandEmployees.ToolTip"));
            this.btnUnderTenThousandEmployees.UseVisualStyleBackColor = true;
            this.btnUnderTenThousandEmployees.Click += new System.EventHandler(this.btnUnderTenThousandEmployees_Click);
            // 
            // lbJdbcUrl
            // 
            resources.ApplyResources(this.lbJdbcUrl, "lbJdbcUrl");
            this.lbJdbcUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbJdbcUrl.Name = "lbJdbcUrl";
            this.tootTipDbUrl.SetToolTip(this.lbJdbcUrl, resources.GetString("lbJdbcUrl.ToolTip"));
            // 
            // tbDbUrl
            // 
            resources.ApplyResources(this.tbDbUrl, "tbDbUrl");
            this.tbDbUrl.Name = "tbDbUrl";
            this.tootTipDbUrl.SetToolTip(this.tbDbUrl, resources.GetString("tbDbUrl.ToolTip"));
            this.tbDbUrl.MouseLeave += new System.EventHandler(this.tbDbUrl_MouseLeave);
            this.tbDbUrl.MouseHover += new System.EventHandler(this.tbDbUrl_MouseHover);
            // 
            // tbDdUserName
            // 
            resources.ApplyResources(this.tbDdUserName, "tbDdUserName");
            this.tbDdUserName.Name = "tbDdUserName";
            this.tootTipDbUrl.SetToolTip(this.tbDdUserName, resources.GetString("tbDdUserName.ToolTip"));
            // 
            // tbDbPassword
            // 
            resources.ApplyResources(this.tbDbPassword, "tbDbPassword");
            this.tbDbPassword.Name = "tbDbPassword";
            this.tootTipDbUrl.SetToolTip(this.tbDbPassword, resources.GetString("tbDbPassword.ToolTip"));
            // 
            // btnDbLogin
            // 
            resources.ApplyResources(this.btnDbLogin, "btnDbLogin");
            this.btnDbLogin.Name = "btnDbLogin";
            this.tootTipDbUrl.SetToolTip(this.btnDbLogin, resources.GetString("btnDbLogin.ToolTip"));
            this.btnDbLogin.UseVisualStyleBackColor = true;
            this.btnDbLogin.Click += new System.EventHandler(this.btnDbLogin_Click);
            // 
            // lbDbPassword
            // 
            resources.ApplyResources(this.lbDbPassword, "lbDbPassword");
            this.lbDbPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDbPassword.Name = "lbDbPassword";
            this.tootTipDbUrl.SetToolTip(this.lbDbPassword, resources.GetString("lbDbPassword.ToolTip"));
            // 
            // lbDdUsername
            // 
            resources.ApplyResources(this.lbDdUsername, "lbDdUsername");
            this.lbDdUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDdUsername.Name = "lbDdUsername";
            this.tootTipDbUrl.SetToolTip(this.lbDdUsername, resources.GetString("lbDdUsername.ToolTip"));
            // 
            // lbApiServerUrl
            // 
            resources.ApplyResources(this.lbApiServerUrl, "lbApiServerUrl");
            this.lbApiServerUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbApiServerUrl.Name = "lbApiServerUrl";
            this.tootTipDbUrl.SetToolTip(this.lbApiServerUrl, resources.GetString("lbApiServerUrl.ToolTip"));
            // 
            // tbApiServerUrl
            // 
            resources.ApplyResources(this.tbApiServerUrl, "tbApiServerUrl");
            this.tbApiServerUrl.Name = "tbApiServerUrl";
            this.tootTipDbUrl.SetToolTip(this.tbApiServerUrl, resources.GetString("tbApiServerUrl.ToolTip"));
            // 
            // tbApiUserName
            // 
            resources.ApplyResources(this.tbApiUserName, "tbApiUserName");
            this.tbApiUserName.Name = "tbApiUserName";
            this.tootTipDbUrl.SetToolTip(this.tbApiUserName, resources.GetString("tbApiUserName.ToolTip"));
            // 
            // tbApiPassword
            // 
            resources.ApplyResources(this.tbApiPassword, "tbApiPassword");
            this.tbApiPassword.Name = "tbApiPassword";
            this.tootTipDbUrl.SetToolTip(this.tbApiPassword, resources.GetString("tbApiPassword.ToolTip"));
            // 
            // btnApiLogin
            // 
            resources.ApplyResources(this.btnApiLogin, "btnApiLogin");
            this.btnApiLogin.Name = "btnApiLogin";
            this.tootTipDbUrl.SetToolTip(this.btnApiLogin, resources.GetString("btnApiLogin.ToolTip"));
            this.btnApiLogin.UseVisualStyleBackColor = true;
            this.btnApiLogin.Click += new System.EventHandler(this.btnApiLogin_Click);
            // 
            // lbApiPassworda
            // 
            resources.ApplyResources(this.lbApiPassworda, "lbApiPassworda");
            this.lbApiPassworda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbApiPassworda.Name = "lbApiPassworda";
            this.tootTipDbUrl.SetToolTip(this.lbApiPassworda, resources.GetString("lbApiPassworda.ToolTip"));
            // 
            // lbApiUserName
            // 
            resources.ApplyResources(this.lbApiUserName, "lbApiUserName");
            this.lbApiUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbApiUserName.Name = "lbApiUserName";
            this.tootTipDbUrl.SetToolTip(this.lbApiUserName, resources.GetString("lbApiUserName.ToolTip"));
            // 
            // tbCtrlAcceleratedTestingTool
            // 
            resources.ApplyResources(this.tbCtrlAcceleratedTestingTool, "tbCtrlAcceleratedTestingTool");
            this.tbCtrlAcceleratedTestingTool.Controls.Add(this.tbPgAccessSetup);
            this.tbCtrlAcceleratedTestingTool.Controls.Add(this.tbPgWTKTesting);
            this.tbCtrlAcceleratedTestingTool.Name = "tbCtrlAcceleratedTestingTool";
            this.tbCtrlAcceleratedTestingTool.SelectedIndex = 0;
            this.tbCtrlAcceleratedTestingTool.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tootTipDbUrl.SetToolTip(this.tbCtrlAcceleratedTestingTool, resources.GetString("tbCtrlAcceleratedTestingTool.ToolTip"));
            // 
            // bJobWorker
            // 
            this.bJobWorker.WorkerReportsProgress = true;
            // 
            // tootTipDbUrl
            // 
            this.tootTipDbUrl.AutomaticDelay = 0;
            // 
            // progressAccessTabBar
            // 
            resources.ApplyResources(this.progressAccessTabBar, "progressAccessTabBar");
            this.progressAccessTabBar.BackColor = System.Drawing.Color.DarkGreen;
            this.progressAccessTabBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressAccessTabBar.Name = "progressAccessTabBar";
            this.tootTipDbUrl.SetToolTip(this.progressAccessTabBar, resources.GetString("progressAccessTabBar.ToolTip"));
            // 
            // progressWtkTabBar
            // 
            resources.ApplyResources(this.progressWtkTabBar, "progressWtkTabBar");
            this.progressWtkTabBar.BackColor = System.Drawing.Color.DarkGreen;
            this.progressWtkTabBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressWtkTabBar.Name = "progressWtkTabBar";
            this.tootTipDbUrl.SetToolTip(this.progressWtkTabBar, resources.GetString("progressWtkTabBar.ToolTip"));
            // 
            // AcceleratedTestingTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCtrlAcceleratedTestingTool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AcceleratedTestingTool";
            this.tootTipDbUrl.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.AcceleratedTestingTool_Load);
            this.tbPgWTKTesting.ResumeLayout(false);
            this.tbPgWTKTesting.PerformLayout();
            this.tbPgAccessSetup.ResumeLayout(false);
            this.tbPgAccessSetup.PerformLayout();
            this.pDbProvider.ResumeLayout(false);
            this.pDbProvider.PerformLayout();
            this.tbCtrlAcceleratedTestingTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbPgWTKTesting;
        private System.Windows.Forms.TabPage tbPgAccessSetup;
        private System.Windows.Forms.Label lbApiServerUrl;
        private System.Windows.Forms.TextBox tbApiServerUrl;
        private System.Windows.Forms.TextBox tbApiUserName;
        private System.Windows.Forms.TextBox tbApiPassword;
        private System.Windows.Forms.Button btnApiLogin;
        private System.Windows.Forms.Label lbApiPassworda;
        private System.Windows.Forms.Label lbApiUserName;
        private System.Windows.Forms.TabControl tbCtrlAcceleratedTestingTool;
        private System.Windows.Forms.Label lbJdbcUrl;
        private System.Windows.Forms.TextBox tbDbUrl;
        private System.Windows.Forms.TextBox tbDdUserName;
        private System.Windows.Forms.TextBox tbDbPassword;
        private System.Windows.Forms.Button btnDbLogin;
        private System.Windows.Forms.Label lbDbPassword;
        private System.Windows.Forms.Label lbDdUsername;
        private System.Windows.Forms.CheckBox chbTopEmployeesShowWage;
        private System.Windows.Forms.Button btnUnderTenThousandEmployees;
        private System.Windows.Forms.Label lbFirstFiveHundredEmployees;
        private System.Windows.Forms.CheckBox cbLimitEmployeesShowWage;
        private System.Windows.Forms.Button btnFirstFiveHundredEmployees;
        private System.Windows.Forms.Label lbFromTenToSeventyFiveThousandEmployees;
        private System.Windows.Forms.CheckBox cbMegaEmployeesShowWage;
        private System.Windows.Forms.Button btnFromTenToSeventyFiveThousandEmployees;
        private System.Windows.Forms.Label lbUnderTenThousandEmployees;
        private System.Windows.Forms.Button btnExtractDataFromDb;
        private System.Windows.Forms.Label lbLicenseCode;
        private System.Windows.Forms.TextBox tbLicenseCode;
        private System.Windows.Forms.Label lbShiftGuaranteeTestStartDate;
        private System.Windows.Forms.Button btnExtractPayRule;
        private System.Windows.Forms.Button btnShiftGuaranteeTestGather;
        private System.Windows.Forms.Button btnShiftGuaranteeTestClean;
        private System.Windows.Forms.Button btnShiftGuaranteeTestPopulate;
        private System.Windows.Forms.Label lbShiftGuaranteeTest;
        private System.Windows.Forms.Button btnPunchRoundTestGather;
        private System.Windows.Forms.Button btnPunchRoundTestClean;
        private System.Windows.Forms.Button btnExceptionTestGather;
        private System.Windows.Forms.Button btnPunchRoundTestPopulate;
        private System.Windows.Forms.Button btnExceptionTestClean;
        private System.Windows.Forms.Label lbPunchRoundTest;
        private System.Windows.Forms.Button btnExceptionTestPopulate;
        private System.Windows.Forms.Label lbExceptionTest;
        private System.Windows.Forms.Label lbPunchRoundTestStartDate;
        private System.Windows.Forms.Label lbExceptionTestStartDate;
        private System.Windows.Forms.Button btnOvertimeTestGather;
        private System.Windows.Forms.Button btnOvertimeTestClean;
        private System.Windows.Forms.Button btnOvertimeTestPopulate;
        private System.Windows.Forms.Label lbOvertimeTest;
        private System.Windows.Forms.Label lbOvertimeTestStartDate;
        private System.Windows.Forms.Button btnTimecardTestGather;
        private System.Windows.Forms.Button btnTimecardTestClean;
        private System.Windows.Forms.Button btnTimecardTestPopulate;
        private System.Windows.Forms.Label lbTimecardTest;
        private System.Windows.Forms.Label lbTimecardTestStartDate;
        private System.Windows.Forms.MaskedTextBox tbExceptionTestStartDate;
        private System.Windows.Forms.MaskedTextBox mtbPunchRoundTestStartDate;
        private System.Windows.Forms.MaskedTextBox mtbShiftGuaranteeTestStartDate;
        private System.Windows.Forms.MaskedTextBox mtbTimecardTestStartDate;
        private System.Windows.Forms.MaskedTextBox mtbOvertimeTestStartDate;
        private ColorfulProgressBar progressWtkTabBar;
        private System.ComponentModel.BackgroundWorker bJobWorker;
        private System.Windows.Forms.Label lbWtkTabJobStatusInfo;
        private System.Windows.Forms.Label lbWtkTabJobStatusDescription;
        private ColorfulProgressBar progressAccessTabBar;
        private System.Windows.Forms.Label lbAccessTabJobStatusInfo;
        private System.Windows.Forms.Label lbAccessTabJobDescription;
        private System.Windows.Forms.Panel pDbProvider;
        private System.Windows.Forms.RadioButton rbOracleProvider;
        private System.Windows.Forms.RadioButton rbSqlProvider;
        private System.Windows.Forms.Label lbDbProvider;
        private System.Windows.Forms.Label lbLargeEmployeesInfo;
        private System.Windows.Forms.ToolTip tootTipDbUrl;
    }
}