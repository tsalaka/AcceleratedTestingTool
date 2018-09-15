namespace Kronos.AcceleratedTool.UI
{
    partial class AcceleratedTestingToolLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcceleratedTestingToolLogin));
            this.lbEnterYourKey = new System.Windows.Forms.Label();
            this.lbAuthorizedLicensedOnly = new System.Windows.Forms.Label();
            this.tbLoginFormPasswordBox = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEnterYourKey
            // 
            resources.ApplyResources(this.lbEnterYourKey, "lbEnterYourKey");
            this.lbEnterYourKey.Name = "lbEnterYourKey";
            // 
            // lbAuthorizedLicensedOnly
            // 
            resources.ApplyResources(this.lbAuthorizedLicensedOnly, "lbAuthorizedLicensedOnly");
            this.lbAuthorizedLicensedOnly.Name = "lbAuthorizedLicensedOnly";
            // 
            // tbLoginFormPasswordBox
            // 
            resources.ApplyResources(this.tbLoginFormPasswordBox, "tbLoginFormPasswordBox");
            this.tbLoginFormPasswordBox.Name = "tbLoginFormPasswordBox";
            this.tbLoginFormPasswordBox.UseSystemPasswordChar = true;
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AcceleratedTestingToolLogin
            // 
            this.AcceptButton = this.btnSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbLoginFormPasswordBox);
            this.Controls.Add(this.lbAuthorizedLicensedOnly);
            this.Controls.Add(this.lbEnterYourKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AcceleratedTestingToolLogin";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEnterYourKey;
        private System.Windows.Forms.Label lbAuthorizedLicensedOnly;
        private System.Windows.Forms.TextBox tbLoginFormPasswordBox;
        private System.Windows.Forms.Button btnSubmit;
    }
}