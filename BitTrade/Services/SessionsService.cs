using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using BitTrade.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BitTrade.Services
{
    public class SessionsService
    {
        HttpClient _client = new HttpClient();

        public SessionsService() {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        public Users Login(User user) {
            
            var res  = _client.PostAsJsonAsync("user/login", user).Result; // Si mauvais mot de passe, retourne erreur 400 (côté serveur)
            if (res.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public Users Register(User user) {
            var res = _client.PostAsJsonAsync("user/create", user).Result;
            if (res.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }
    }
}