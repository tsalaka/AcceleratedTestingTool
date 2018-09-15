using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataBaseAccess
{
    public interface IQueryFactory
    {
        TQuery Create<TQuery>() where TQuery : IQuery;
        void Release<TQuery>(TQuery query) where TQuery : IQuery;
    }
}
