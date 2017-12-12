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

        public UserController(UsersService usersService) {
            _usersService = usersService;
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
            var edit = _usersService.Edit(user);
            @ViewData["Error"] = null;
            @ViewData["Success"] = null;

            if (edit != null)
            {
                if (edit.Success == true)
                {
                    @ViewData["Success"] = edit.Message;
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
            var delete = _usersService.Delete(user);
            @ViewData["Error"] = null;
            @ViewData["Success"] = null;

            if (delete != null)
            {
                if (delete.Success == true)
                {
                    @ViewData["Success"] = delete.Message;
                    return View();
                }
                @ViewData["Error"] = delete.Message;
            }
            else
            {
                @ViewData["Error"] = "An error occured.";
            }

            return View();
        }
    }
}
