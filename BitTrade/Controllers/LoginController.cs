using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using BitTrade.Models;
using BitTrade.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitTrade.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsersService _service;

        public LoginController(UsersService service) {
            _service = service;
        }

        // GET: /Login/ : Page de connexion / inscription
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Login/Users/
        /*public IActionResult Users()
        {
            var users         = _service.Get();
            ViewData["Users"] = users;

            return View();
        }*/
    }
}
