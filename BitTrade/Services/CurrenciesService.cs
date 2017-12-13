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

        // Retourne la liste des toutes les cryptomonnaies
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

        // Retourne une unique cryptomonnaie selon le MarketName
        public MarketCurrency GetCurrency(string Identifier) {
            var res = _client.GetAsync("currency/" + Identifier).Result;

            if (res.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<MarketCurrencies>(res.Content.ReadAsStringAsync().Result);
                if (data.Success)
                {
                    return data.Result[0];
                }
            }

            return null;
        }

        // Ajoute une cryptomonnaie au favoris d'un utilisateur
        public UserCurrencies AddCurrencyFavorite(UserCurrency userCurrency)
        {
            var toto = userCurrency;
            var res = _client.PostAsJsonAsync("usercurrencies", userCurrency).Result;

            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserCurrencies>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        // Retourne la liste des cryptomonnaies en favoris d'un utilisateur
        public UserCurrencies GetCurrencyFavorites(User user)
        {
            var res = _client.GetAsync("usercurrencies/" + user.Id).Result;
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserCurrencies>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }
    }
}