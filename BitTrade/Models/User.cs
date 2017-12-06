using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public object Apikey { get; set; }
        public string Token { get; set; }
        public int StatutId { get; set; }

        public User() {}
    }

    public class Users
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<User> Result { get; set; }

        public Users() { }
    }
}
