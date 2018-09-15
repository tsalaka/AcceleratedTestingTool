using System;
using System.Windows.Forms;
using Kronos.AcceleratedTool.UI.Resources;

namespace Kronos.AcceleratedTool.UI
{
    public partial class AcceleratedTestingToolLogin : Form
    {
        private const string Password = "KronosGTS";

        public AcceleratedTestingToolLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            // It was agreed that password cryphography will be added later
            // CryphographyService can be used for this purpose. See CryphographyServiceTests unit tests to find a code example
            if (tbLoginFormPasswordBox.Text == Password)
            {
                Hide();
                new AcceleratedTestingTool().ShowDialog();
                Close();
                return;
            }

            MessageBox.Show(ToolUI.MsgIncorrectPassowrdKeyEntered, ToolUI.AuthorizedUsersOnlyLabel);
        }
    }
}
