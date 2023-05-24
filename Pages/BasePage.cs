using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TradingViewE2ETests.Utils;

namespace TradingViewE2ETests.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentManager _extent;
        protected BasePage(IWebDriver driver, ExtentManager extent)
        {
            _driver = driver;
            _extent = extent;
        }

        protected bool IsVerify(string title, bool contains = false)
        {
            if (contains)
                return _driver.Title.Contains(title);
            else
                return _driver.Title.Equals(title);
        }
        protected void WaitUntilElementClickable(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw ex;
            }
        }
        protected void WaitUntilElementIsVisible(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw ex;
            }
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementIsVisible(by);
            try
            {
                return _driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
        }
        protected void Click(By by)
        {
            try
            {
                GetElement(by).Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                throw ex;
            }
        }

        protected void SetText(By by, string text)
        {
            try
            {
                GetElement(by).SendKeys(text);
            }
            catch (ElementNotVisibleException ex)
            {
                throw ex;
            }
        }
        //mouse hover on an element
        protected void MouseHover(By by)
        {
            Actions actions = new Actions(_driver);
            WaitUntilElementClickable(by);
            IWebElement target = _driver.FindElement(by);
            actions.MoveToElement(target).Build(); 
            actions.Perform();
        }

        protected void ClickByJS(By by)
        {
            WaitUntilElementClickable(by);
            try
            {
                IWebElement target = _driver.FindElement(by);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", target);
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
        }
        protected string GetText(By by)
        {
            try
            {
                return GetElement(by).Text;
            }
            catch (ElementNotVisibleException ex)
            {
                throw ex;
            }
        }
        protected string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
}
