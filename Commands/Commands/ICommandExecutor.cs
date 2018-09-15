namespace AcceleratedTool.Commands
{
    public interface ICommandExecutor
    {
        TResult Execute<TCriteria, TResult>(TCriteria criteria);
        void Execute<TCriteria>(TCriteria criteria);
        TResult Execute<TResult>();
    }
}
