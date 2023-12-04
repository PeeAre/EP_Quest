using EP_Quest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EP_Quest.Controllers
{
    public class GreetingCardController : Controller
    {
        private readonly QuestDbContext _dbContext;

        public GreetingCardController(QuestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Greeting Card";

            return View();
        }
    }
}
