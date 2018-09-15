namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public interface IQuery
    {
    }

    public interface IQuery<out TResult> : IQuery
    {
        TResult Execute();
    }

    public interface IQuery<in TCriteria, out TResult> : IQuery
    {
        TResult Execute(TCriteria criteria);
    }
}
