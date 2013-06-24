using Autotests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autotests.Suites
{
    [TestClass]
    public abstract class SuiteBase
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
