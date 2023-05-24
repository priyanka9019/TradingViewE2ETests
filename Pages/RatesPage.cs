using NUnit.Framework;
using OpenQA.Selenium;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Pages
{
    public class RatesPage : BasePage
    {
        private readonly ExtentManager _extent;
        public RatesPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }
        private readonly By btnUserMenu = By.XPath("//div[@class='tv-header__area tv-header__area--user']/button[contains(@class,'tv-header__user-menu-button--anonymous')]");
        private readonly By btnUserLogged = By.XPath("//div[@class='tv-header__area tv-header__area--user']/button[contains(@class,'tv-header__user-menu-button--logged')]");
        private readonly By btnSignIn = By.XPath("//span[text()='Sign in']");
        private By lnkCategory(string category) => By.XPath("//a[@class='tv-category-tab']/div[text()='" + category + "']");
        private readonly By spnUsername = By.XPath("//span[@class='username-HvRChfI1']");
        private readonly string title = "Forex Rates — All Currency Pairs — TradingView";

        private readonly By spnSignOut = By.XPath("//span[text()='Sign Out']");
        public RatesPage VerifyPageTitle()
        {
            try
            {
                Assert.IsTrue(base.IsVerify(title), "Page title is invalid");
                _extent.Info("Rates page title verified");
            }
            catch { _extent.TestFail("Rates page title not verified");
                throw;
            }
            return this;
        }
        public void GoToSignIn()
        {
            Click(btnUserMenu);
            Click(btnSignIn);
        }

        public void SelectCategory(string category)
        {
            ClickByJS(lnkCategory(category));
            _extent.Info(category +" category selected");
        }
        public void IsUserLoggedIn(string username)
        {
            Click(btnUserLogged);
            try
            {
                Assert.True(GetText(spnUsername).Equals(username), "User is not logged in");
                _extent.Info(username + " user logged in successfully!");
            }
            catch { Assert.Fail();
                _extent.TestFail("User not logged in successfully");
                throw;
            }

        }
        public void Logout()
        {
            Click(btnUserLogged);
            Click(spnSignOut);
        }
    }
}
