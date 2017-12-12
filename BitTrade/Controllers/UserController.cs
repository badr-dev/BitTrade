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

        // Page GET: /Users/:Id : Page de détails d'un utilisateur
        [Route("User/Edit/{*Id}")]
        public IActionResult Edit(int Id)
        {
            var user = _usersService.GetUser(Id);
            ViewData["User"] = user;

            return View();
        }

        // Page POST d'édition d'un utilisateur
        [HttpPost]
        public IActionResult Edit(User user)
        {
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
    }
}
