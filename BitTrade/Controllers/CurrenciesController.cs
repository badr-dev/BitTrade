using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        // GET: /Currencies/List
        public IActionResult List()
        {
            return View();
        }

        // GET: /Currencies/Details
        public IActionResult Details()
        {
            return View();
        }
    }
}
