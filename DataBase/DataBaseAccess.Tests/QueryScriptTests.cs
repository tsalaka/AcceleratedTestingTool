using System;
using AcceleratedTool.DataAccess.Common;
using NUnit.Framework;

namespace AcceleratedTool.DataBaseAccess.Tests
{
    [TestFixture]
    public class QueryScriptTests
    {
        [Test]
        public void TestScriptReturnsCorrectly()
        {
            var scriptDictionary = new QueryScriptDictionary();
            scriptDictionary.Queries.Add(ProviderType.Oracle, "Oracle");
            scriptDictionary.Queries.Add(ProviderType.Sql, "Sql");

            Assert.AreEqual("Oracle", scriptDictionary.GetScript(ProviderType.Oracle));
            Assert.AreEqual("Sql", scriptDictionary.GetScript(ProviderType.Sql));
        }

        [Test]
        public void TestThatDefaultScriptReturnsIfSpecficScriptNotFound()
        {
            var scriptDictionary = new QueryScriptDictionary();
            scriptDictionary.Queries.Add(ProviderType.Default, "Default");

            Assert.AreEqual("Default", scriptDictionary.GetScript(ProviderType.Oracle));
            Assert.AreEqual("Default", scriptDictionary.GetScript(ProviderType.Sql));
        }

        [Test]
        public void TestThatExceptionThrowsIfSpecficScriptNotFound()
        {
            var scriptDictionary = new QueryScriptDictionary();

            var ex = Assert.Throws<Exception>(() => scriptDictionary.GetScript(ProviderType.Oracle));
            Assert.AreEqual("No DB script for Oracle provider was found", ex.Message);
        }
    }
}
