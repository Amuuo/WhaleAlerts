using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace WhaleAlertsLibrary.Controllers
{

    public class CryptoCompareApiController
    {
        private HttpClient client = new HttpClient();
        
        public Dictionary<string, Coin> CoinList { get; set; } 
        public Dictionary<string, Exchange> ExchangeList { get; set; }
        public static string            BaseUrl = "https://cryptocompare.com";
        public static string            ApiUrl  = "https://min-api.cryptocompare.com";
        private string                  ApiKey  = "50a1456c0a0ce3b48e955f5998fc196f1b5f53725f597cd8005121c6ee3f24df";

        
        public CryptoCompareApiController()
        {
            client.DefaultRequestHeaders.Add("Authorization", ApiKey);
            PopulateCoinList();
            PopulateExchangeList();
        }

        private void PopulateCoinList()
		{
            var requestUri = new Uri($"{ApiUrl}/data/all/coinlist");
            var result = client.GetAsync(requestUri).Result;
            var reader = new StreamReader(result.Content.ReadAsStream());
            var content = reader.ReadToEnd();

            this.CoinList = JsonSerializer.Deserialize<ApiResponse<Coin>>(content).Data;
        }

        private void PopulateExchangeList()
		{
            var requestUri = new Uri($"{ApiUrl}/data/exchanges/general");
            var result = client.GetAsync(requestUri).Result;
            var reader = new StreamReader(result.Content.ReadAsStream());
            var content = reader.ReadToEnd();

            this.ExchangeList = JsonSerializer.Deserialize<ApiResponse<Exchange>>(content).Data;
        }

        public string GetCoinImageUrl(string symbol)
        {
            return $"{BaseUrl}{CoinList[symbol].ImageUrl}";
        }
    }
    
    public class ApiResponse<T>
	{
        public Dictionary<string,T> Data { get; set; }
        public string? Message { get; set; }
        public string? Response { get; set; }
        public int Type { get; set; }
    }

    public class Exchange
	{
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? LogoUrl { get; set; }
        public string? Description { get; set; }
        public string? Grade { get; set; }
        public string? Country { get; set; }
        public string? CentralizationType { get; set; }
	}


    public class Coin
    {
        public string? Name        { get; set; }
        public string? Url         { get; set; }
        public string? ImageUrl    { get; set; }
        public string? Description { get; set; }
        public string? Algorithm   { get; set; }
        public string? ProofType   { get; set; }
    }

}