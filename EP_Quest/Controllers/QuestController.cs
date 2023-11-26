using EP_Quest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EP_Quest.Controllers
{
    public class QuestController : Controller
    {
        private readonly QuestDbContext _dbContext;

        public QuestController(QuestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Quest";

            return View();
        }
    }
}
