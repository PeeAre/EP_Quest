using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Your Gift";

            return View();
        }
    }
}