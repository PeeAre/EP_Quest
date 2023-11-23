using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class QuestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
