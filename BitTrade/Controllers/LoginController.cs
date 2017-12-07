using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using BitTrade.Models;
using BitTrade.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitTrade.Controllers
{
    public class LoginController : Controller
    {
        private readonly SessionsService _service;

        public LoginController(SessionsService service) {
            _service = service;
        }

        // GET: /Login/ : Page de connexion / inscription
        public IActionResult Index() {
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("_Token");
            HttpContext.Session.Remove("_Id");

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Create(User user) {
            var login = _service.Login(user);
            if (login.Success == true) {
                HttpContext.Session.SetString("_Token", login.Result[0].Token);
                HttpContext.Session.SetInt32("_Id", login.Result[0].Id);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
