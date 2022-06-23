using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Net;
//using Newtonsoft.Json;
using WhaleAlertsLibrary.Models;


namespace WhaleAlertsLibrary.Controllers
{
    public class WhaleTransactionController
    {
        private string ApiKey = "BMEJgT0Gb3URK2b8pWAbu3cWN1x8jZpr";
        private string ApiUrl = "https://api.whale-alert.io/v1/";

        public TransactionList GetWhaleTransactions()
        {

            var httpClient = new System.Net.Http.HttpClient();

            httpClient.BaseAddress = new Uri($"{ApiUrl}transactions");
            var request = new System.Net.Http.HttpRequestMessage();
            request.Headers.Add("X-WA-API-KEY", ApiKey);
            var response = httpClient.SendAsync(request);
            response.Wait();
            var json = new StreamReader(response.Result.Content.ReadAsStreamAsync().Result).ReadToEnd();

            //var json = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();
            /*
            var request = WebRequest.Create($"{ApiUrl}transactions");
            request.Headers.Add($"X-WA-API-KEY: {ApiKey}");
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var json = reader.ReadToEnd();
            */
            return JsonSerializer.Deserialize<TransactionList>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //var test = JsonConvert.DeserializeObject(json);            
        }
    }
}
