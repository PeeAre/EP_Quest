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
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                _dbContext.Database.Migrate();
            }

            _dbContext.Database.EnsureCreated();
            ViewBag.Title = "Quest";

            return View();
        }
    }
}
