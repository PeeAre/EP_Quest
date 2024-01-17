using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Your Gift";

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