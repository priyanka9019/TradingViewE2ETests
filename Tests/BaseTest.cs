using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TradingViewE2ETests.Registry;
using TradingViewE2ETests.Utils;
using TradingViewE2ETests.TestData;
using Newtonsoft.Json;

namespace TradingViewE2ETests.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected readonly PageRegister Pages;
        public ExtentManager extent;
        public TestDataInput testData = null;

        [OneTimeSetUp]
        public void SetUp()
        {
            LoadTestData();
            if (testData != null)
            {
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(testData.baseUrl);
            }
           else { Assert.Fail("Testdata not loaded sucessfully"); }

        }
        public BaseTest()
        {
            Driver = new ChromeDriver();
            extent = new ExtentManager();
            Pages = new PageRegister(Driver, extent);
        }

        public void LoadTestData()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../TestData/TestDataInput.json"));

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                testData = JsonConvert.DeserializeObject<TestDataInput>(json);
            }
        }

        
        [OneTimeTearDown]
        public void TearDown()
        {
            extent.ExtentEnd();
            Driver.Quit();
        }
    }
}