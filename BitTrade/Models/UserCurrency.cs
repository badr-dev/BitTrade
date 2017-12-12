using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class UserCurrency
    {
        public long Id { get; set; }
        public string MarketName { get; set; }
        public long UserForeignKey { get; set; }
        public User User { get; set; }

        public UserCurrency() {}
    }

    public class UserCurrencies
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<UserCurrency> Result { get; set; }

        public UserCurrencies() { }
    }
}
