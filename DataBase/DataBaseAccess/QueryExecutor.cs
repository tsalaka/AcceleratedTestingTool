using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataBaseAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IQueryFactory _queryFactory;

        public QueryExecutor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public TResult Execute<TCriteria, TResult>(TCriteria criteria)
        {
            var query = _queryFactory.Create<IQuery<TCriteria, TResult>>();
            try
            {
                return query.Execute(criteria);
            }
            finally
            {
                _queryFactory.Release(query);
            }
        }

        public TResult Execute<TResult>()
        {
            var query = _queryFactory.Create<IQuery<TResult>>();
            try
            {
                return query.Execute();
            }
            finally
            {
                _queryFactory.Release(query);
            }
        }
    }
}
