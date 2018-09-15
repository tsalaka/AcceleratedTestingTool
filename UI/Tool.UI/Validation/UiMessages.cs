using System.Windows.Forms;
using Kronos.AcceleratedTool.UI.Resources;

namespace Kronos.AcceleratedTool.UI.Validation
{
    public class UiMessages : IUiMessages
    {
        public void TestLoginMessage(bool isSuccessful)
        {
            var message = isSuccessful ? ToolUI.MsgSuccessfulLogin : ToolUI.MsgUnsuccessfulLogin;
            MessageBox.Show(message, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UrlMessage()
        {
            MessageBox.Show(ToolUI.MsgEnterValidURL, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void InvalidStartDateMessage()
        {
            MessageBox.Show(ToolUI.MsgEnterValidStartDate, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void StartDateShouldBeGreaterThanMinimumDate()
        {
            MessageBox.Show(ToolUI.StartDateShouldBeGreaterThanMinimumDate, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LicenseMessage()
        {
            MessageBox.Show(ToolUI.MsgEnterLicense, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CredentialsMessage()
        {
            MessageBox.Show(ToolUI.MsgEnterCredentials, ToolUI.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
