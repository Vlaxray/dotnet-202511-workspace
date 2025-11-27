using RestSharp;
using System.Collections.Generic;
public class RetriverManager
{
    private RestClient _client;
    private RestRequest _request;
    private const string URL = "https://yh-finance.p.rapidapi.com";

    public RetriverManager()
    {
        _client = new RestClient("https://yh-finance.p.rapidapi.com");
        _request = new RestRequest("", Method.Get);
        _request.AddHeader("X-RapidAPI-Key", "2726d63df2mshdcadee91ad6da56p1b3a40jsn2d24942c60d4");
        _request.AddHeader("X-RapidAPI-Host", "yh-finance.p.rapidapi.com");
    }
    public object Search(string value)
    {
        _client = new RestClient(URL +"/v1/finance/search?q={value}");
        var response = this._client.Execute(this._request);
        return response.Content;
    }
}