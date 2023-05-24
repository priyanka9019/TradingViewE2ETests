namespace TradingViewE2ETests.TestData
{
    public class TestDataInput
    {
        public UserDetails UserDetails { get; set; }
        public RatesCategory RatesCategory { get; set; }
        public List<Currency> Currencies { get; set; }
        public string baseUrl { get; set; }
    }
    public class Currency
    {
        public string countryCurrency { get; set; }
        public string countryCode { get; set; }
        public string countryTitle { get; set; }
    }

    public class RatesCategory
    {
        public string continent { get; set; }
        public string currencyTitle { get; set; }
        public string exchangeCode { get; set; }
        public string exchangeName { get; set; }
    }


    public class UserDetails
    {
        public string userName { get; set; }
        public string password { get; set; }
    }


}
