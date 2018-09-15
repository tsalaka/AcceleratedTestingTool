namespace Kronos.AcceleratedTool.UI.Validation
{
    public interface IUiMessages
    {
        void UrlMessage();

        void InvalidStartDateMessage();

        void StartDateShouldBeGreaterThanMinimumDate();

        void LicenseMessage();

        void CredentialsMessage();

        void TestLoginMessage(bool isSuccessful);
    }
}