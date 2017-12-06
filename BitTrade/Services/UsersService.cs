using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using BitTrade.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BitTrade.Services
{
    public class UsersService
    {
        HttpClient _client = new HttpClient();
        string _baseUrl = "http://localhost:5000/api/";

        /*public List<User> GetUsers() {

            var res = _client.GetAsync("http://localhost:5000").Result;

            // Si le serveur répond (200)
            if (res.IsSuccessStatusCode) {
                var data = res.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<User>>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }*/

        public User GetUser(int Id) {

            var res = _client.GetAsync(_baseUrl + "user/" + Id).Result;

            if (res.IsSuccessStatusCode) {
                var data = JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
                return data.Result[0];
            }

            return null;
        }
    }
}