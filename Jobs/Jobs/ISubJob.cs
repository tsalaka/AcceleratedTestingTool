namespace AcceleratedTool.Jobs
{
    public interface ISubJob<TCriteria>
        where TCriteria : class
    {
        void Run(TCriteria criteria);
    }

    public interface ISubJob<TCriteria, TResult>
        where TCriteria : class
    {
        TResult Run(TCriteria criteria);
    }
}
