using System.Security.Cryptography;
using Kronos.AcceleratedTool.UI.Cryphography;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Tool.UI.Tests
{
    [TestFixture]
    public class CryphographyServiceTests
    {
        private const string Password = "KronosTest";
        private const string PasswordHash = "32532b144aba848860b6c157bfe6910fc4d6dbeb9a01b1819ceabc25ee92fcbb";

        [Test]
        public void TestThatVerifyMethodWorkdCorrectly()
        {
            using (var sha = SHA256.Create())
            {
                var cryphographyService = new CryphographyService();
                Assert.IsTrue(cryphographyService.VerifyHash(sha, "KronosTest", PasswordHash));
                Assert.IsFalse(cryphographyService.VerifyHash(sha, "WrongPassword", PasswordHash));
            }
        }

        [Test]
        public void TestThatGetHashMethodWorkdCorrectly()
        {
           using (var sha = SHA256.Create())
            {
                var cryphographyService = new CryphographyService();
                Assert.AreEqual(PasswordHash, cryphographyService.GetHash(sha, Password));
            }
        }
    }
}
