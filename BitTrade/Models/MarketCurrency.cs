using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace BitTrade.Models
{
    public class MarketCurrency
    {
        public string MarketName { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public double Last { get; set; }
        public double BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        public double PrevDay { get; set; }
        public DateTime Created { get; set; }

        public MarketCurrency() {}
    }

    public class MarketCurrencies
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<MarketCurrency> Result { get; set; }

        public MarketCurrencies() {}
    }
}
