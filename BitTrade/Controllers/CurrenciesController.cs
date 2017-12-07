using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitTrade.Models;
using BitTrade.Services;

namespace BitTrade.Controllers
{
    /**
     * Controller Currencies
     **/
    public class CurrenciesController : Controller
    {
        private readonly CurrenciesService _service;

        public CurrenciesController(CurrenciesService service) {
            _service = service;
        }

        // GET: /Currencies/
        public IActionResult Index()
        {
            var currencies = _service.GetCurrencies();

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
