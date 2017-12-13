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
    public class UserController : Controller
    {
        private readonly UsersService _usersService;
        private readonly CurrenciesService _currenciesService;

        public UserController(
            UsersService usersService,
            CurrenciesService currenciesService
        ) {
            _usersService = usersService;
            _currenciesService = currenciesService;
        }

        // Page GET: Page de détails d'un utilisateur
        public IActionResult Edit()
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home"); 
            var userId = _usersService.GetUserId();
            var user = _usersService.GetUser(userId.Value);
            ViewData["User"] = user;

            return View();
        }

        // Page POST d'édition d'un utilisateur
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            user.Token = _usersService.GetUserToken();
            var edit = _usersService.Edit(user);
            @ViewData["Error"] = null;
            @ViewData["Success"] = null;

            if (edit != null)
            {
                if (edit.Success == true)
                {
                    @ViewData["Success"] = edit.Message;
                    @ViewData["User"] = edit.Result[0];

                    return View();
                }
                @ViewData["Error"] = edit.Message;
            }
            else
            {
                @ViewData["Error"] = "An error occured.";
            }

            return View();
        }

        // Page GET: Page de favoris d'un utilisateur
        public IActionResult Favorites()
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            var userId = _usersService.GetUserId();
            var user = _usersService.GetUser(userId.Value);
            var favorites = _currenciesService.GetCurrencyFavorites(user);
            ViewData["Favorites"] = favorites;

            return View();
        }

        // Page GET de suppression de l'utilisateur
        public IActionResult Unsubscribe(int Id)
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            var userId = _usersService.GetUserId();
            var user = _usersService.GetUser(userId.Value);
            ViewData["User"] = user;

            return View();   
        }

        // Page POST de suppression d'un user
        [HttpPost]
        public IActionResult Unsubscribe(User user)
        {
            if (!_usersService.IsConnected())
                return RedirectToAction("Index", "Home");
            user.Token = _usersService.GetUserToken();
            var delete = _usersService.Delete(user);

            @TempData["Error"] = null;
            @TempData["Success"] = null;

            if (delete != null)
            {
                if (delete.Success == true)
                {
                    HttpContext.Session.Remove("_Token");
                    HttpContext.Session.Remove("_Id");
                    HttpContext.Session.Remove("_Firstname");
                    HttpContext.Session.Remove("_Surname");

                    @TempData["Success"] = delete.Message;
                } else {
                    @TempData["Error"] = delete.Message;   
                }
            }
            else
            {
                @TempData["Error"] = "An error occured.";
            }

            return RedirectToAction("Signin", "Login");
        }
    }
}
