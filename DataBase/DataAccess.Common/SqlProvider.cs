using System;
using System.Data.Common;
using System.Data.SqlClient;
using AcceleratedTool.DataAccess.Common.Dapper;
using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataAccess.Common
{
    public class SqlProvider : IDbProvider
    {
        public ProviderType Type { get { return ProviderType.Sql;} }

        public DbConnection CreateConnection(DatabaseSettings databaseSettings)
        {
            if (string.IsNullOrEmpty(databaseSettings.Url))
                throw new ArgumentNullException("connectionString");

            var connectionString = string.Format("{0};User Id={1};Password={2}", databaseSettings.Url, databaseSettings.UserName, databaseSettings.Password);
            return new SqlConnection(connectionString);
        }
    }
}
