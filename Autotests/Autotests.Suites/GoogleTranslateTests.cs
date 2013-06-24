using Autotests.Utilities;
using Autotests.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autotests.Suites
{
    [TestClass]
    public class GoogleTranslateTests : SuiteBase
    {
        [TestMethod]
        public void TranslateText()
        {
            #region TestData

            const string languageFrom = "en";
            const string languageTo = "ru";
            const string textEn = "hello";
            const string textRu = "привет";

            #endregion

            Pages.Index.Open(languageFrom, languageTo);

            var result = Pages.Index.Translate(textEn);

            Assert.AreEqual(textRu, result,
                string.Format("{0} != {1}.", textRu, result));
        }

        [TestMethod]
        public void CheckJavaScriptEscape()
        {
            #region TestData

            const string languageFrom = "en";
            const string languageTo = "en";
            const string javascript = "alert(1);";

            #endregion

            Pages.Index.Open(languageFrom, languageTo);

            var result = Pages.Index.Translate(javascript);

            Assert.AreEqual(javascript, result,
                "JavaScript was executed.");
        }

        [TestMethod]
        public void ClearSourceText()
        {
            Pages.Index.Open();
            Pages.Index.Translate(RandomHelper.RandomString);
            Pages.Index.Clear();

            Assert.IsTrue(string.IsNullOrEmpty(Pages.Index.SourceText),
                "Source text was not cleared.");
        }

        [TestMethod]
        public void NavigateWebsiteTranslator()
        {
            Pages.Index.Open();
            Pages.Index.OpenWebsiteTranslator();

            Assert.IsTrue(Browser.Url.Contains(Pages.Manager.Websites.Index.BaseUrl),
                "WebsiteTranslator was not opened.");
        }
    }
}
