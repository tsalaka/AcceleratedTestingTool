namespace Kronos.AcceleratedTool.License
{
    public interface ILicenseChecker
    {
        bool IsLicenseValid(byte[] bytes, string license);
    }
}