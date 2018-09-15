namespace AcceleratedTool.DataBaseAccess
{
    public interface IQueryExecutor
    {
        TResult Execute<TCriteria, TResult>(TCriteria criteria);
        TResult Execute<TResult>();
    }
}
