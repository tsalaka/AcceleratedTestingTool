using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Transactions;
using Dapper;
using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataAccess.Common.Dapper
{
    public class DapperTransactionalDataContext : ITransactionalDataContext
    {
        private bool _disposed;
        private readonly DbConnection _connection;
        private readonly TransactionScope _transactionScope;

        public DapperTransactionalDataContext(DbConnection connection)
        {
            _connection = connection;
            _transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
            _connection.Open();
        }


        ~DapperTransactionalDataContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transactionScope.Dispose();
                    _connection.Dispose();
                }
            }

            _disposed = true;

        }

        public int ExecuteNonQuery(string storedProcedureName, object parameters = null, int? commandTimeout = new int?())
        {
            int result = _connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return result;
        }

        public T ExecuteScalar<T>(string storedProcedureName, object parameters = null, int? commandTimeout = new int?())
        {
            IEnumerable<T> result = _connection.Query<T>(storedProcedureName, parameters,
                                                          commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return result.First();
        }

        public IEnumerable<T> ExecuteQuery<T>(string storedProcedureName, object parameters = null, int? commandTimeout = new int?())
        {
            return _connection.Query<T>(storedProcedureName, parameters,
                                                            commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
        }

        public void Complete()
        {
            _transactionScope.Complete();
            _connection.Close();
        }
    }
}
