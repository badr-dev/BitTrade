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

        public UsersService() {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        public User GetUser(int Id) {

            var res = _client.GetAsync("user/" + Id).Result;

            if (res.IsSuccessStatusCode) {
                var data = JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
                return data.Result[0];
            }

            return null;
        }
    }
}