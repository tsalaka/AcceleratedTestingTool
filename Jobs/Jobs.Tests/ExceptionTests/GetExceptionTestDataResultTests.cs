using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Results;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class GetExceptionTestDataResultTests
    {
        [Test]
        public void TestThatItemsCollectionAreNotNull()
        {
            var result = new GetExceptionTestDataResult();
            Assert.NotNull(result.Items);
        }
    }
}
