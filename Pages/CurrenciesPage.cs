using NUnit.Framework;
using OpenQA.Selenium;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Pages
{
    public class CurrenciesPage:BasePage
    {
        private readonly ExtentManager _extent;
        public CurrenciesPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }
        private readonly By btnSearch = By.XPath("//button[@aria-label='Search' and contains(@class,'tv-header-search-container__button--full')]");
        private readonly By inputSearch = By.Name("query");
        private readonly By divSymbol = By.CssSelector("div.listContainer-vWG52QBW");
        private readonly By btnSeeOverview = By.XPath("//div[@class='wrap-nfAwWSqk']//button[@value='symbols']");
        private  string title(string currency) => currency+ " Currencies — Rates and Performance — TradingView";
        public CurrenciesPage VerifyPageTitle(string currency)
        {
            try
            {
                Assert.IsTrue(base.IsVerify(title(currency)), "Page title is invalid");
                _extent.Info("Currency page title verified");
            }
            catch { _extent.TestFail("Currency page title not verified"); 
                throw; }
            return this;
        }
        public void SearchSymbol(string exchange, string symbol)
        {
            Click(btnSearch);
            SetText(inputSearch, exchange +":"+ symbol);
            MouseHover(divSymbol);
            Click(btnSeeOverview);
            _extent.Info(exchange + ":" + symbol +" symbol searched");
        }
    }
}
