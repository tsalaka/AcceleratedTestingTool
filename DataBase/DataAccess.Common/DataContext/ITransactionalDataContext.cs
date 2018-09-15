using System;
using System.Collections.Generic;

namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public interface ITransactionalDataContext : IDisposable
    {
        /// <summary>
        /// Executes a query that resturns no result set
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"> </param>
        /// <returns></returns>
        int ExecuteNonQuery(string storedProcedureName, object parameters = null, int? commandTimeout = null);

        /// <summary>
        /// Executes a query that returns a strongly typed single of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"> </param>
        /// <returns></returns>
        T ExecuteScalar<T>(string storedProcedureName, object parameters = null, int? commandTimeout = null);

        /// <summary>
        /// Executes a query that returns a strongly typed enumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"> </param>
        /// <returns></returns>
        IEnumerable<T> ExecuteQuery<T>(string storedProcedureName, object parameters = null, int? commandTimeout = null);

        void Complete();
    }
}
