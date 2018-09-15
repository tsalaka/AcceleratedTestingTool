using System.Collections.Generic;

namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public interface IDataContext
    {
        IDbProvider DbProvider { get; set; }

        /// <summary>
        /// Executes a query that returns a strongly typed enumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queries"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"> </param>
        /// <returns></returns>
        IEnumerable<T> ExecuteQuery<T>(QueryScriptDictionary queries, object parameters = null, int? commandTimeout = 0);

        /// <summary>
        /// Executes a query that returns a strongly typed single of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queries"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"> </param>
        /// <returns></returns>
        T ExecuteScalar<T>(QueryScriptDictionary queries, object parameters = null, int? commandTimeout = null);

        ITransactionalDataContext BeginTransaction();

        bool TestConnection();
    }
}
