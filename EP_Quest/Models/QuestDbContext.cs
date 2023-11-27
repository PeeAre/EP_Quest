using Microsoft.EntityFrameworkCore;

namespace EP_Quest.Models
{
    public class QuestDbContext : DbContext
    {
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<CompletionTime> CompletionTimes { get; set; }

        public QuestDbContext(DbContextOptions<QuestDbContext> options)
            : base(options)
        {
        }
    }
}