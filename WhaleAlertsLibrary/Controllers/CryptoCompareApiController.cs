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
        public string GetSymbolLogo(string symbol) {
            
            Uri requestAddress = new Uri($"https://min-api.cryptocompare.com/data/all/coinlist?fsym={symbol}");
            
            
            var request = HttpWebRequest.Create(requestAddress);
            request.Headers.Add("Authorization", "50a1456c0a0ce3b48e955f5998fc196f1b5f53725f597cd8005121c6ee3f24df");            
            var responseStream = request.GetRequestStreamAsync();
            var result = new StreamReader(responseStream.Result);
            var resultString = result.ToString();
                                                                
        }
    }


}