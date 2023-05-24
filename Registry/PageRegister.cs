
using AventStack.ExtentReports;
using OpenQA.Selenium;
using TradingViewE2ETests.Pages;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Registry
{
    public class PageRegister
    {
        public RatesPage RatesPage { get; }
        public SymbolsPage SymbolsPage { get; }
        public SignInPage SignInPage { get; }
        public CurrenciesPage CurrenciesPage { get; }
        public PageRegister(IWebDriver driver, ExtentManager extent)
        {
            SignInPage = new SignInPage(driver, extent);
            RatesPage = new RatesPage(driver, extent);
            SymbolsPage = new SymbolsPage(driver, extent);
            CurrenciesPage = new CurrenciesPage(driver, extent);
        }
    }
}
