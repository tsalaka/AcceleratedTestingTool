using System;
using System.Data.Common;
using AcceleratedTool.DataAccess.Common.Dapper;
using AcceleratedTool.DataAccess.Common.DataContext;
using Oracle.ManagedDataAccess.Client;

namespace AcceleratedTool.DataAccess.Common
{
    public class OracleProvider : IDbProvider
    {
        public ProviderType Type { get { return ProviderType.Oracle;} }

        public DbConnection CreateConnection(DatabaseSettings databaseSettings)
        {
            if (string.IsNullOrEmpty(databaseSettings.Url))
                throw new ArgumentNullException("connectionString");

            var connectionString = string.Format("{0};User Id={1};Password=\"{2}\"", databaseSettings.Url, databaseSettings.UserName, databaseSettings.Password);
            return new OracleConnection(connectionString);
        }
    }
}
