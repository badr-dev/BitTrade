using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class Currency
    {
        public string MarketCurrency { get; set; }
        public string BaseCurrency { get; set; }
        public string MarketCurrencyLong { get; set; }
        public string BaseCurrencyLong { get; set; }
        public double MinTradeSize { get; set; }
        public string MarketName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string Notice { get; set; }
        public bool? IsSponsored { get; set; }
        public string LogoUrl { get; set; }

        public Currency() {}
    }

    public class Currencies
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Currency> Result { get; set; }

        public Currencies() {}
    }
}
