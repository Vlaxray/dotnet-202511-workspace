using System;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
static void Main(string[] args){}
    public class Earnings
    {
        public int maxAge { get; set; }
        public EarningsChart earningsChart { get; set; }
        public FinancialsChart financialsChart { get; set; }
        public string financialCurrency { get; set; }
        public string defaultMethodology { get; set; }
    }

    public class EarningsChart
    {
        public List<Quarterly> quarterly { get; set; }
        public double currentQuarterEstimate { get; set; }
        public string currentQuarterEstimateDate { get; set; }
        public string currentCalendarQuarter { get; set; }
        public int currentQuarterEstimateYear { get; set; }
        public string currentFiscalQuarter { get; set; }
        public List<int> earningsDate { get; set; }
        public bool isEarningsDateEstimate { get; set; }
    }

    public class FinancialsChart
    {
        public List<Yearly> yearly { get; set; }
        public List<Quarterly> quarterly { get; set; }
    }

    public class PageViews
    {
        public string midTermTrend { get; set; }
        public string longTermTrend { get; set; }
        public string shortTermTrend { get; set; }
    }

    public class Quarterly
    {
        public string date { get; set; }
        public double actual { get; set; }
        public double estimate { get; set; }
        public string fiscalQuarter { get; set; }
        public string calendarQuarter { get; set; }
        public string difference { get; set; }
        public string surprisePct { get; set; }
        public object revenue { get; set; }
        public object earnings { get; set; }
    }

    public class QuoteResponse
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }

    public class QuoteSummary
    {
        public SummaryDetail summaryDetail { get; set; }
        public Earnings earnings { get; set; }
    }

    public class Result
    {
        public string language { get; set; }
        public string region { get; set; }
        public string quoteType { get; set; }
        public string typeDisp { get; set; }
        public string quoteSourceName { get; set; }
        public bool triggerable { get; set; }
        public string customPriceAlertConfidence { get; set; }
        public QuoteSummary quoteSummary { get; set; }
        public List<string> components { get; set; }
        public string currency { get; set; }
        public double trailingAnnualDividendYield { get; set; }
        public double revenue { get; set; }
        public double priceToSales { get; set; }
        public string marketState { get; set; }
        public double epsTrailingTwelveMonths { get; set; }
        public double epsForward { get; set; }
        public double epsCurrentYear { get; set; }
        public double epsNextQuarter { get; set; }
        public double priceEpsCurrentYear { get; set; }
        public double priceEpsNextQuarter { get; set; }
        public long sharesOutstanding { get; set; }
        public double bookValue { get; set; }
        public double fiftyDayAverage { get; set; }
        public double fiftyDayAverageChange { get; set; }
        public double fiftyDayAverageChangePercent { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double twoHundredDayAverageChange { get; set; }
        public double twoHundredDayAverageChangePercent { get; set; }
        public object marketCap { get; set; }
        public double forwardPE { get; set; }
        public double priceToBook { get; set; }
        public int sourceInterval { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public PageViews pageViews { get; set; }
        public int gmtOffSetMilliseconds { get; set; }
        public bool esgPopulated { get; set; }
        public bool tradeable { get; set; }
        public bool cryptoTradeable { get; set; }
        public bool hasPrePostMarketData { get; set; }
        public object firstTradeDateMilliseconds { get; set; }
        public int priceHint { get; set; }
        public double totalCash { get; set; }
        public long floatShares { get; set; }
        public object ebitda { get; set; }
        public double shortRatio { get; set; }
        public double targetPriceHigh { get; set; }
        public double targetPriceLow { get; set; }
        public double targetPriceMean { get; set; }
        public double targetPriceMedian { get; set; }
        public double heldPercentInsiders { get; set; }
        public double heldPercentInstitutions { get; set; }
        public double postMarketChangePercent { get; set; }
        public int postMarketTime { get; set; }
        public double postMarketPrice { get; set; }
        public double postMarketChange { get; set; }
        public double regularMarketChange { get; set; }
        public double regularMarketChangePercent { get; set; }
        public int regularMarketTime { get; set; }
        public double regularMarketPrice { get; set; }
        public double regularMarketDayHigh { get; set; }
        public string regularMarketDayRange { get; set; }
        public double regularMarketDayLow { get; set; }
        public int regularMarketVolume { get; set; }
        public int sharesShort { get; set; }
        public int sharesShortPrevMonth { get; set; }
        public double shortPercentFloat { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public int bidSize { get; set; }
        public int askSize { get; set; }
        public string exchange { get; set; }
        public string market { get; set; }
        public string messageBoardId { get; set; }
        public string fullExchangeName { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string financialCurrency { get; set; }
        public double regularMarketOpen { get; set; }
        public int averageDailyVolume3Month { get; set; }
        public int averageDailyVolume10Day { get; set; }
        public double beta { get; set; }
        public double fiftyTwoWeekLowChange { get; set; }
        public double fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public double fiftyTwoWeekHighChange { get; set; }
        public double fiftyTwoWeekHighChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public int exDividendDate { get; set; }
        public int earningsTimestamp { get; set; }
        public int earningsTimestampStart { get; set; }
        public int earningsTimestampEnd { get; set; }
        public double trailingAnnualDividendRate { get; set; }
        public double trailingPE { get; set; }
        public string symbol { get; set; }
        public double? dividendsPerShare { get; set; }
        public double? dividendRate { get; set; }
        public double? dividendYield { get; set; }
        public int? dividendDate { get; set; }
    }

    public class Root
    {
        public QuoteResponse quoteResponse { get; set; }
    }

    public class SummaryDetail
    {
        public int maxAge { get; set; }
        public int priceHint { get; set; }
        public double previousClose { get; set; }
        public double open { get; set; }
        public double dayLow { get; set; }
        public double dayHigh { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public double regularMarketOpen { get; set; }
        public double regularMarketDayLow { get; set; }
        public double regularMarketDayHigh { get; set; }
        public int exDividendDate { get; set; }
        public double payoutRatio { get; set; }
        public double beta { get; set; }
        public double trailingPE { get; set; }
        public double forwardPE { get; set; }
        public int volume { get; set; }
        public int regularMarketVolume { get; set; }
        public int averageVolume { get; set; }
        public int averageVolume10days { get; set; }
        public int averageDailyVolume10Day { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public int bidSize { get; set; }
        public int askSize { get; set; }
        public object marketCap { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public double allTimeHigh { get; set; }
        public double allTimeLow { get; set; }
        public double priceToSalesTrailing12Months { get; set; }
        public double fiftyDayAverage { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double trailingAnnualDividendRate { get; set; }
        public double trailingAnnualDividendYield { get; set; }
        public string currency { get; set; }
        public object fromCurrency { get; set; }
        public object toCurrency { get; set; }
        public object lastMarket { get; set; }
        public object coinMarketCapLink { get; set; }
        public object algorithm { get; set; }
        public bool tradeable { get; set; }
        public double? dividendRate { get; set; }
        public double? dividendYield { get; set; }
        public double? fiveYearAvgDividendYield { get; set; }
    }

    public class Yearly
    {
        public int date { get; set; }
        public object revenue { get; set; }
        public object earnings { get; set; }
    }


    
    public static async Task Main()
    {}
    

    var client = new RestClient("https://yh-finance.p.rapidapi.com/market/v2/get-quotes?region=US&symbols=AMD%2CIBM%2CAAPL");
    var request = new RestRequest("", Method.Get);
    request.AddHeader("x-rapidapi-key", "YOUR_KEY_HERE");
    request.AddHeader("x-rapidapi-host", "yh-finance.p.rapidapi.com");

    RestResponse response = client.Execute(request);

    if (response.IsSuccessful && response.Content != null)
    {
        try
        {
            Root rootData = JsonConvert.DeserializeObject<Root>(response.Content)!;

            if (rootData?.quoteResponse?.result != null)
            {
                foreach (var result in rootData.quoteResponse.result)
                {
                    Console.WriteLine($"Simbolo: {result.symbol}");
                    Console.WriteLine($"Nome lungo: {result.longName}");
                    Console.WriteLine($"Prezzo attuale: {result.regularMarketPrice}");
                    Console.WriteLine($"Earnings Currency: {result.quoteSummary?.earnings?.financialCurrency}");
                    Console.WriteLine(new string('-', 50));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore nella deserializzazione: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Errore nella richiesta API");
    }

