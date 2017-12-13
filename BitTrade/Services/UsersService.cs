using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
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
    public class UsersService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        HttpClient _client = new HttpClient();

        public UsersService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        // GET : Get single user
        public User GetUser(int Id)
        {
            var res = _client.GetAsync("user/" + Id).Result;
            if (res.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
                return data.Result[0];
            }

            return null;
        }

        // PUT : Edit user
        public Users Edit(User user)
        {
            var res = _client.PutAsJsonAsync("user/" + user.Id, user).Result;
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        // DELETE : Delete user
        public Users Delete(User user)
        {
            var res = _client.DeleteAsync("user/" + user.Id).Result;
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public int? GetUserId() 
        {
            var context = _httpContextAccessor.HttpContext;
            if (context.Session.GetInt32("_Id") > 0) {
                return context.Session.GetInt32("_Id");
            }
            return null;
        }

        public string GetUserToken()
        {
            var context = _httpContextAccessor.HttpContext;
            var token = context.Session.GetString("_Token");

            return context.Session.GetString("_Token");
        }

        public bool IsConnected() 
        {
            var context = _httpContextAccessor.HttpContext;

            User user = new User();
            var token = context.Session.GetString("_Token");
            user.Token = token;
            var res = _client.PostAsJsonAsync("checktoken", user).Result;
            if (res.IsSuccessStatusCode) {
                var content = JsonConvert.DeserializeObject<Users>(res.Content.ReadAsStringAsync().Result);
                if (content.Success) {
                    return true;
                }
            }

            return false;
        }

        public string GetUserName() 
        {
            var context   = _httpContextAccessor.HttpContext;

            var firstname = context.Session.GetString("_Firstname");
            var surname   = context.Session.GetString("_Surname");

            return (firstname + surname);
        }
    }
}