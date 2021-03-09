using KutseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KutseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Ootan sind minu peole";
            int hour = DateTime.Now.Hour;
            ViewData["Greeting"] = Greeting(DateTime.Now);
            return View();
        }
        
        [HttpGet]
        public IActionResult Questionnaire()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Questionnaire(Guest guest)
        {
            if (ModelState.IsValid)
            {
                return View("Greetings", guest);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string Greeting(DateTime dateTime)
        {
            int hour = dateTime.Hour;
            return hour switch
            {
                >= 4 and < 12 => "Tere hommikust",
                >= 12 and < 16 => "Tere päevast",
                >= 16 and < 23 => "Tere õhtust",
                _ => "Head ööd"
            };
        }
    }
}
