using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class TodoModel
    {
        [JsonProperty("userId")]
        public int userId { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("completed")]
        public bool completed { get; set; }

        public TodoModel() { }
    }
}
