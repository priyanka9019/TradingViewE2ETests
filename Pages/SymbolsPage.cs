using OpenQA.Selenium;
using NUnit.Framework;
using System.Web;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Pages
{
    public class SymbolsPage : BasePage
    {
        private readonly ExtentManager _extent;
        public SymbolsPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }

        private readonly By symbolHeaderTitle = By.CssSelector("h1.tv-symbol-header__first-line");
        //Verify overview redirects on correct page
        public void AssertOnRightPage(string exchange, string symbol, string symbolTitle)
        {
            Uri myUri = new Uri(GetCurrentUrl(), UriKind.Absolute);
            try
            {
                //get the value of uri parameter
                string paramExchange = HttpUtility.ParseQueryString(myUri.Query).Get("exchange");
                string headerTitle = GetText(symbolHeaderTitle);
                Assert.True(paramExchange.Equals(exchange)
                    && myUri.ToString().Contains(symbol)
                    && headerTitle.Equals(symbolTitle), "Currencies overview not on correct page");
                _extent.TestPass("Currencies overview on right page!");

            }
            catch
            {
                _extent.TestFail("Currencies overview on incorrect page");
                Assert.Fail();               
                throw;
            }
        }
    }
}
