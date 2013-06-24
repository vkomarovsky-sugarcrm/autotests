using System;

namespace Autotests.Utilities.WebElement
{
    public class WebElementNotFoundException : Exception
    {
        public WebElementNotFoundException(string message) : base(message)
        {
        }
    }
}
