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
        [Route("Currencies/Details/{*Identifier}")]
        public IActionResult Details(string Identifier)
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            var currency = _currenciesService.GetCurrency(Identifier);

            ViewData["MarketCurrency"] = currency;
            ViewData["UserId"] = _usersService.GetUserId();

            return View();
        }

        // POST: /Currencies/Favorites
        [HttpPost]
        public IActionResult Favorites(UserCurrency userCurrency)
        {
            var favorite = _currenciesService.AddCurrencyFavorite(userCurrency);
            @ViewData["Error"] = null;
            @ViewData["Success"] = null;

            if (favorite != null)
            {
                if (favorite.Success == true)
                {
                    @ViewData["Success"] = "";
                    return View();
                } else {
                    @ViewData["Error"] = favorite.Message;   
                }
            }
            else
            {
                @ViewData["Error"] = "";
            }

            return RedirectToAction("Index", "Currencies");;
        }
    }
}
