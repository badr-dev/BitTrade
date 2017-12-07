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
        private readonly SessionsService _sessionsService;
        private readonly UsersService _usersService;

        public LoginController(
            SessionsService sessionsService,
            UsersService usersService
        ) {
            _sessionsService = sessionsService;
            _usersService = usersService;
        }

        public IActionResult Signin() {
            if (!_usersService.IsConnected())
                return View();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register() {
            if (!_usersService.IsConnected())
                return View();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout() {
            if (_usersService.IsConnected()) {
                HttpContext.Session.Remove("_Token");
                HttpContext.Session.Remove("_Id");

                return RedirectToAction("Signin", "Login");
            }
            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public IActionResult Register(User user) {
            var login = _sessionsService.Register(user);
            @ViewData["Error"] = null;
            @ViewData["Success"] = null;

            if (login != null) {
                if (login.Success == true) {
                    @ViewData["Success"] = "You have been correctly register! You can now signin with " + user.Email + ".";
                    return View();
                }
                @ViewData["Error"] = login.Message;
            } else {
                @ViewData["Error"] = "This e-mail address is already used.";
            }

            return View();
        }

        [HttpPost]
        public IActionResult Signin(User user) {
            var login = _sessionsService.Login(user);
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
