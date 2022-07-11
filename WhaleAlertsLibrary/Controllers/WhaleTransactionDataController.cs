using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
//using Newtonsoft.Json;
using WhaleAlertsLibrary.Models;
using System.Data.SqlClient;

namespace WhaleAlertsLibrary.Controllers
{
    public class WhaleTransactionDataController
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


        public static List<WhaleTransaction> GetWhaleTransactionSQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=VAULT;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.WhaleTransaction FOR JSON AUTO", conn);

            var transactions = new List<WhaleTransaction>();
            string json = "";
            
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    json += reader[0].ToString();
                    /*
                    transactions.Add(new WhaleTransaction
                    {
                        Amount            = (float)reader["amount"],
                        Amount_USD        = (float)reader["amount_usd"],
                        Blockchain        = (string)reader["blockchain"],
                        Hash              = (string)reader["hash"],
                        Symbol            = (string)reader["symbol"],
                        Timestamp         = (int)reader["timestamp"],
                        Transaction_Count = (int)reader["transaction_count"]
                    });
                    Console.WriteLine($"id: {reader["id"]}");
                    */
                }
            }

            


            return transactions; 
        }
    }
}
