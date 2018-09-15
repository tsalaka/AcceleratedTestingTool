namespace Kronos.AcceleratedTool.UI.Validation
{
    public interface IUiValidator
    {
        bool IsLicenseValid(string license);

        bool IsLoginValid(string userName, string password);

        ValidatorState IsMaskedTextBoxDateStringValid(string dateString);

        bool IsUrlValid(string url);
    }
}