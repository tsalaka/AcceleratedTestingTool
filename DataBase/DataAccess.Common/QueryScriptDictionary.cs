using System;
using System.Collections.Generic;

namespace AcceleratedTool.DataAccess.Common
{
    public class QueryScriptDictionary
    {
        public QueryScriptDictionary()
        {
            Queries = new Dictionary<ProviderType, string>();
        }

        public Dictionary<ProviderType, string> Queries { get; private set; }

        public void AddQuery(ProviderType provider, string script)
        {
            if (!Queries.ContainsKey(provider))
                Queries.Add(provider, script);
            else
            {
                Queries[provider] = script;
            }
        }

        public string GetScript(ProviderType provider)
        {
            if (Queries.ContainsKey(provider))
                return Queries[provider];

            if (Queries.ContainsKey(ProviderType.Default))
                return Queries[ProviderType.Default];

            throw new Exception(string.Format("No DB script for {0} provider was found", provider));
        }
    }
}
