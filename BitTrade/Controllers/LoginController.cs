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

        public IActionResult Signin() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("_Token");
            HttpContext.Session.Remove("_Id");

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Register(User user) {
            var login = _service.Register(user);
            @ViewData["Error"] = null;

            if (login.Success == true) {
                if (login != null) {
                    HttpContext.Session.SetString("_Token", login.Result[0].Token);
                    HttpContext.Session.SetInt32("_Id", login.Result[0].Id);
                    HttpContext.Session.SetString("_Firsname", login.Result[0].Firstname);
                    HttpContext.Session.SetString("_Surname", login.Result[0].Surname);

                    return RedirectToAction("Index", "Home");
                }
                @ViewData["Error"] = login.Message;
            } else {
                @ViewData["Error"] = "Please check your informations.";
            }

            return View();
        }

        [HttpPost]
        public IActionResult Signin(User user) {
            var login = _service.Login(user);
            @ViewData["Error"] = null;

            if (login != null) {
                if (login.Success == true) {
                    HttpContext.Session.SetString("_Token", login.Result[0].Token);
                    HttpContext.Session.SetInt32("_Id", login.Result[0].Id);
                    HttpContext.Session.SetString("_Firsname", login.Result[0].Firstname);
                    HttpContext.Session.SetString("_Surname", login.Result[0].Surname);

                    return RedirectToAction("Index", "Home");
                }
                @ViewData["Error"] = login.Message;
            } else {
                @ViewData["Error"] = "Please check your credentials.";
            }

            return View();
        }
    }
}
