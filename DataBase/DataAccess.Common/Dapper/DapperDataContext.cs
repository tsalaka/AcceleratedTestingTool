using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataAccess.Common.Dapper
{
    public class DapperDataContext : IDataContext
    {
        private readonly DatabaseSettings _databaseSettings;
        private IDbProvider _dbProvider;

        public DapperDataContext(DatabaseSettings databaseSettings, IDbProvider dbProvider)
        {
            _databaseSettings = databaseSettings;
            _dbProvider = dbProvider;
        }

        public IDbProvider DbProvider
        {
            get { return _dbProvider; }
            set { _dbProvider = value; }
        }

        public IEnumerable<T> ExecuteQuery<T>(QueryScriptDictionary scripts, object parameters = null, int? commandTimeout = 0)
        {
            using (var connection = _dbProvider.CreateConnection(_databaseSettings))
            {
                connection.Open();

                var result = connection.Query<T>(scripts.GetScript(_dbProvider.Type), parameters, commandType: CommandType.Text, commandTimeout: commandTimeout);
                connection.Close();
                return result;
            }
        }

        public ITransactionalDataContext BeginTransaction()
        {
            var connection = _dbProvider.CreateConnection(_databaseSettings);

            return new DapperTransactionalDataContext(connection);
        }

        public T ExecuteScalar<T>(QueryScriptDictionary scripts, object parameters = null, int? commandTimeout = null)
        {
            return ExecuteQuery<T>(scripts, parameters, commandTimeout).FirstOrDefault();
        }

        public bool TestConnection()
        {
            IDbConnection connection = null;
            try
            {
                connection = _dbProvider.CreateConnection(_databaseSettings);
                connection.Open();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }
    }
}
