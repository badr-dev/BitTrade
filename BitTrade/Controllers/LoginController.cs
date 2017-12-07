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
        private readonly SessionsService _service;

        public LoginController(SessionsService service) {
            _service = service;
        }

        // GET: /Login/ : Page de connexion / inscription
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var login = _service.Login(user);
            if (login.Success) {
                
            }
            return RedirectToAction("Home", "Index"); 
        }
    }
}
