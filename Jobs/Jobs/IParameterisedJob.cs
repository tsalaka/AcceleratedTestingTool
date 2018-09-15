namespace AcceleratedTool.Jobs
{
    public interface IParameterisedJob<TCriteria>
    {
        JobStatus Run(TCriteria criteria);
    }
}
