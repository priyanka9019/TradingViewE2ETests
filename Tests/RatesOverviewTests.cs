using NUnit.Framework;
namespace TradingViewE2ETests.Tests
{
    [TestFixture]
    public class SymbolsTests : BaseTest
    {
        string currencyPair = string.Empty, symbolHeaderTitle = string.Empty;
        [OneTimeSetUp]
        public void BeforeTests()
        {
            if (testData.Currencies.Count != 0)
            {
                currencyPair = testData.Currencies[0].countryCurrency + testData.Currencies[1].countryCurrency;
                symbolHeaderTitle = testData.Currencies[0].countryTitle + " / " + testData.Currencies[1].countryTitle;
            }
            //SignIn by email
            Pages.RatesPage.GoToSignIn();
            Pages.SignInPage.SignInByEmail(testData.UserDetails.userName, testData.UserDetails.password);

        }

        [Test]
        [Description("To verify currency pair overview on correct page")]
        public void VerifyCurrencyOverviewPage()
        {
            extent.StartTest("Verify Currency Overview Page");
            // Verify is user logged in
            Pages.RatesPage.IsUserLoggedIn(testData.UserDetails.userName);

            Pages.RatesPage.VerifyPageTitle()
                           .SelectCategory(testData.RatesCategory.continent);

            Pages.CurrenciesPage.VerifyPageTitle(testData.RatesCategory.currencyTitle)
                                .SearchSymbol(testData.RatesCategory.exchangeCode, currencyPair);
            //Assert on right page
            Pages.SymbolsPage.AssertOnRightPage(testData.RatesCategory.exchangeCode, currencyPair, symbolHeaderTitle);

        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            Pages.RatesPage.Logout();
        }
    }
}