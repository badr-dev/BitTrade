using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using BitTrade.Models;
using Newtonsoft.Json;
namespace BitTrade.Services
{
    public class UsersService
    {
        HttpClient _client = new HttpClient();

        public User Get() {

            var res = _client.GetAsync("http://localhost:5000").Result;

            if (res.IsSuccessStatusCode) {
                var test = JsonConvert.DeserializeObject<User>(res.Content.ReadAsStringAsync().Result);
                return JsonConvert.DeserializeObject<User>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }
    }
}