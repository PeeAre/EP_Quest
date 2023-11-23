using EP_Quest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EP_Quest.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuestDbContext _dbContext;

        public HomeController(QuestDbContext dbContext)
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
            ViewBag.Title = "Your Quest";

            return View();
        }
    }
}