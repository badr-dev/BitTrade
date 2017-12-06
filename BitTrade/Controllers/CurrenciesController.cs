using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitTrade.Models;

namespace BitTrade.Controllers
{
    /**
     * Controller Currencies
     **/
    public class CurrenciesController : Controller
    {
        // GET: /Currencies/
        public IActionResult Index()
        {
            List<Currency> currencies = new List<Currency>();

            currencies.Add(new Currency() {
                MarketCurrency = "LTC",
                BaseCurrency = "BTC",
                MarketCurrencyLong = "Litecoin",
                BaseCurrencyLong = "Bitcoin",
                MinTradeSize = 0.02739726,
                MarketName = "BTC-LTC",
                LogoUrl = "https://bittrexblobstorage.blob.core.windows.net/public/6defbc41-582d-47a6-bb2e-d0fa88663524.png"
            });

            currencies.Add(new Currency()
            {
                MarketCurrency = "DOGE",
                BaseCurrency = "BTC",
                MarketCurrencyLong = "Dogecoin",
                BaseCurrencyLong = "Bitcoin",
                MinTradeSize = 1315.78947368,
                MarketName = "BTC-DOGE",
                LogoUrl = "https://bittrexblobstorage.blob.core.windows.net/public/a2b8eaee-2905-4478-a7a0-246f212c64c6.png"
            });

            ViewData["Currencies"] = currencies;

            return View();
        }

        // GET: /Currencies/Details
        public IActionResult Details()
        {
            return View();
        }
    }
}
