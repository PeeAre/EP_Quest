using EP_Quest.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private TelegramSender _telegramSender;

        public HomeController(IConfiguration configuration, TelegramSender telegramSender)
        {
            _configuration = configuration;
            _telegramSender = telegramSender;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Your Journey";

            await _telegramSender.SendAsync("Someone came");

            //if (!Request.Cookies.ContainsKey("KeyPhrase"))
            //    Response.Cookies.Append("KeyPhrase", _configuration["Phrases:Key phrase"]);

            return View();
        }
        public void Login()
        {
            Response.Cookies.Append("KeyPhrase", _configuration["Phrases:Key phrase"]);
        }
    }
}