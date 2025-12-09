public class AssetProfile
{
    public string sector { get; set; }
    public string industry { get; set; }
    public string longBusinessSummary { get; set; }
    public string fullTimeEmployees { get; set; }
    public string website { get; set; }
}

public class SummaryProfile
{
    public string exchange { get; set; }
    public string marketCap { get; set; }
    public string priceHint { get; set; }
    public string previousClose { get; set; }
    public string open { get; set; }
    public string dayHigh { get; set; }
    public string dayLow { get; set; }
}

public class FundProfile
{
    public string peRatio { get; set; }
    public string eps { get; set; }
    public string dividendYield { get; set; }
    public string beta { get; set; }
    public string revenue { get; set; }
    public string profitMargins { get; set; }
}

public class FundamentalsResponse
{
    public AssetProfile assetProfile { get; set; }
    public SummaryProfile summaryProfile { get; set; }
    public FundProfile fundProfile { get; set; }
}
