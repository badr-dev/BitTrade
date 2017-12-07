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
        private readonly CurrenciesService _currenciesService;
        private readonly UsersService _usersService;

        public CurrenciesController(
            CurrenciesService currenciesService,
            UsersService usersService
        ) {
            _currenciesService = currenciesService;
            _usersService = usersService;
        }

        // GET: /Currencies/
        public IActionResult Index()
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            var currencies = _currenciesService.GetCurrencies();

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
