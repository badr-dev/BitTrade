using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class User
    {
        // [JsonProperty("Id")]
        public long Id { get; set; }
        // [JsonProperty("Firstname")]
        public string Firstname { get; set; }
        // [JsonProperty("Surname")]
        public string Surname { get; set; }
        // [JsonProperty("Email")]
        public string Email { get; set; }
        // [JsonProperty("Password")]
        public string Password { get; set; }
        // [JsonProperty("Apikey")]
        public string Apikey { get; set; }

        public User() { }
    }
}
