using KutseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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
                SendMessage(guest);
                return View("Greetings", guest);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Greetings(Guest guest)
        {
            return View("Greetings", guest);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Notificate(string name, string email)
        {
            SendMessage(name, email);
            ViewData["Message"] = "Ootan sind minu peole";
            int hour = DateTime.Now.Hour;
            ViewData["Greeting"] = Greeting(DateTime.Now);
            return View("Index");
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

        private const string Sender = "contacts@laus19.thkit.ee";
        private const string Password = "siinSaabTeavitadaKeegi";
        private const string Organizer = "bchik3@gmail.com";
        private string[] months = new string[] { null, "jaanuar", "veebruar", "märts", "aprill", "mai", "juuni", "juuli", "august", "september", "oktoober", "november", "detsember" };
        
        private void SendMessage(Guest guest)
        {
            try
            {
                var message = new MailMessage();
                var smtpClient = new SmtpClient("smtp.zone.eu", 587)
                {
                    Credentials = new NetworkCredential(Sender, Password),
                    EnableSsl = true
                };
                message.From = new MailAddress(Sender, "Nikolas Laus");
                message.To.Add(Organizer);
                var attend = Convert.ToBoolean(guest.WillAttend) ? "tuleb peole" : "ei tule peole";
                message.Body = $"{guest.Name} vastas, et {attend}.\nTelefoninumber: {guest.Phone}.\nE-post: {guest.Email}.";
                message.Subject = "Pidu";
                smtpClient.Send(message);
                ViewData["Message"] = "Kiri on saadetud.";
            }
            catch (Exception)
            {
                ViewData["Message"] = "Kiri saatmine on ebaõnnestunud.";
            }
        }

        private void SendMessage(string name, string email)
        {
            try
            {
                var message = new MailMessage();
                var smtpClient = new SmtpClient("smtp.zone.eu", 587)
                {
                    Credentials = new NetworkCredential(Sender, Password),
                    EnableSsl = true
                };
                message.From = new MailAddress(Sender, "Nikolas Laus");
                message.To.Add(Organizer);
                message.To.Add(email);
                message.Body =
                    $"{name}, oled oodatud!\nPidu toimub 23. {months[2]} 2021 a, kell 14:00.\nLisainfo: {Organizer}";
                message.Subject = "Meeldetuletus";
                smtpClient.Send(message);
                ViewData["Message"] = "Kiri on saadetud.";
            }
            catch (Exception)
            {
                
            }
        }
    }
}
