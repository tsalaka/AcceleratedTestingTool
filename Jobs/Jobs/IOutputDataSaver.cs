namespace AcceleratedTool.Jobs
{
    public interface IOutputDataSaver
    {
        void Save(string fileName, byte[] content);
    }
}
