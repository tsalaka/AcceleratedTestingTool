using System.Data.Common;
using AcceleratedTool.DataAccess.Common.Dapper;

namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public interface IDbProvider
    {
        ProviderType Type { get; }

        DbConnection CreateConnection(DatabaseSettings databaseSettings);
    }
}
