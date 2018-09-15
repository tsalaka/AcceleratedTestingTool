using System.Collections.Generic;
using System.Linq;
using AcceleratedTool.DataAccess.Common;
using AcceleratedTool.DataAccess.Common.DataContext;

namespace AcceleratedTool.DataBaseAccess
{
    public abstract class ProviderAdaptedQuery<T> : IQuery<List<T>>
    {
        private readonly IDataContext _dataContext;

        protected ProviderAdaptedQuery(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected List<T> Execute(string sqlScript, string oracleScript)
        {
            var scriptDictionary = new QueryScriptDictionary();
            scriptDictionary.AddQuery(ProviderType.Oracle, oracleScript);
            scriptDictionary.AddQuery(ProviderType.Sql, sqlScript);

            var entities = _dataContext.ExecuteQuery<T>(scriptDictionary);
            return entities.ToList<T>();
        }

        protected List<T> Execute(string script)
        {
            var scriptDictionary = new QueryScriptDictionary();
            scriptDictionary.AddQuery(ProviderType.Default, script);

            var entities = _dataContext.ExecuteQuery<T>(scriptDictionary);
            return entities.ToList<T>();
        }

        public abstract List<T> Execute();
    }
}
