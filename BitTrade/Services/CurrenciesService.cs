using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using BitTrade.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BitTrade.Services
{
    public class CurrenciesService
    {
        HttpClient _client = new HttpClient();

        public CurrenciesService() {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        public List<Currency> GetCurrencies() {

            var res = _client.GetAsync("currencies").Result;

            if (res.IsSuccessStatusCode) {
                var data = JsonConvert.DeserializeObject<Currencies>(res.Content.ReadAsStringAsync().Result);
                if (data.Success) {
                    return data.Result;   
                }
            }

            return null;
        }
    }
}