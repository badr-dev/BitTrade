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

namespace BitTrade.Services
{
    public class UsersService
    {
        HttpClient _client = new HttpClient();

        public List<User> Get() {

            var res  = _client.GetAsync("http://localhost:5000").Result;
            var data = res.Content.ReadAsStringAsync().Result;

            // Si le serveur répond (200)
            if (res.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<List<User>>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }
    }
}