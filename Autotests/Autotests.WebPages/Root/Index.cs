using System;
using System.Diagnostics.Contracts;
using Autotests.Utilities;
using Autotests.Utilities.Tags;
using Autotests.Utilities.WebElement;

namespace Autotests.WebPages.Root
{
    public class Index : PageBase
    {
        #region Elements

        private static readonly WebElement SourceEdit = new WebElement().ById("source");
        private static readonly WebElement ResutlText = new WebElement().ById("result_box");
        private static readonly WebElement ClearButton = new WebElement().ById("clear");
        private static readonly WebElement WebsiteTranslatorLink = new WebElement()
            .ByAttribute(TagAttributes.Href, Pages.Manager.Websites.Index.BaseUrl.ToString(), exactMatch: false);

        #endregion

        public void Open(string from, string to)
        {
            Contract.Requires(from != to);

            var url = new Uri(string.Format("{0}#{1}/{2}/", BaseUrl, from, to));

            Navigate(url);
        }

        public string SourceText
        {
            get { return SourceEdit.Text; }
        }

        public string ResultText
        {
            get { return ResutlText.Text; }
        }

        public string Translate(string text)
        {
            SourceEdit.Text = text;

            if (!string.IsNullOrEmpty(text))
            {
                Contract.Assert(WaitHelper.SpinWait(() => !string.IsNullOrEmpty(ResutlText.Text), TimeSpan.FromSeconds(10)));
            }

            return ResultText;
        }

        public void Clear()
        {
            Contract.Assert(ClearButton.Exists(10));

            ClearButton.Click(useJQuery: false);
        }

        public void OpenWebsiteTranslator()
        {
            WebsiteTranslatorLink.Click(useJQuery: false);
        }
    }
}
