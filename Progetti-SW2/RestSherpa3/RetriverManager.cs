using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
public class RetriverManager
{
    private RestClient _client;
    private RestRequest _request;
    private const string URL = "https://yh-finance.p.rapidapi.com";

    public RetriverManager(string apiKey)
    {
        _client = new RestClient("URL");
        _request = new RestRequest("", Method.Get);
        _request.AddHeader("X-RapidAPI-Key", "2726d63df2mshdcadee91ad6da56p1b3a40jsn2d24942c60d4");
        _request.AddHeader("X-RapidAPI-Host", "https://yh-finance.p.rapidapi.com");
    }
    public EarningsChart? Search(string value)
    {
        _client = new RestClient(URL +"/v1/finance/search?q={value}");
        var response = this._client.Execute(this._request);
        return DeserealizeData(response.Content!);
    }
    private EarningsChart DeserealizeData(string response)
    {
        return JsonSerializer.Deserialize<EarningsChart>(response)!;
    }
    public string? GetNews(string symbol)
    {
        _client = new RestClient(URL+"/stock/v2/get-news?region=US&lang=en-US&symbol="+symbol);
        var response = this._client.Execute(_request);
        return response.Content;
    }
}