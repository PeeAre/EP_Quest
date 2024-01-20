using EP_Quest.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration, TelegramSender telegramSender)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Your Journey";

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