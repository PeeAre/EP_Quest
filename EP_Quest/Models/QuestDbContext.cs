using Microsoft.EntityFrameworkCore;

namespace EP_Quest.Models
{
    public class QuestDbContext : DbContext
    {
        public DbSet<CompletionTime> CompletionTimes { get; set; }

        public QuestDbContext(DbContextOptions<QuestDbContext> options)
            : base(options)
        {

        }
    }
}