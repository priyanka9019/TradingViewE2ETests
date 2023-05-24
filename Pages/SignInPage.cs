using NUnit.Framework;
using OpenQA.Selenium;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Pages
{
    public class SignInPage : BasePage
    {
        private readonly ExtentManager _extent;
        private readonly By spnEmail = By.XPath("//span[text()='Email']");
        private readonly By inputUsername = By.Name("username");
        private readonly By inputPassword = By.Name("password");
        private readonly By btnSignIn = By.XPath("//button[contains(@id,'email-signin__submit-button')]");
        private readonly string title = "Chart – Pound to Yen Rate — TradingView";
        public SignInPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }

        public SignInPage VerifyPageTitle()
        {
            try
            {
                Assert.IsTrue(base.IsVerify(title, true));
                _extent.Info("Sign in page title verified");
            }
            catch { _extent.TestFail("Sign in page title not verified");
                throw;
            }
            return this;
        }
        public void SignInByEmail(string username, string password)
        {
            Click(spnEmail);
            SetText(inputUsername, username);
            SetText(inputPassword, password);
            Click(btnSignIn);
        }
               
    }
}
