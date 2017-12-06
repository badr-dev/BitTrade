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
        private readonly UsersService _service;

        public UserController(UsersService service) {
            _service = service;
        }

        // GET: /Users/:Id : Page de détails d'un utilisateur
        [Route("User/{*Id}")]
        public IActionResult Index(int Id)
        {
            var user = _service.GetUser(Id);
            ViewData["User"] = user;

            return View();
        }
    }
}
