using Microsoft.EntityFrameworkCore;

namespace EP_Quest.Models
{
    public class QuestRepository : IQuestRepository
    {
        private readonly QuestDbContext _context;
        public QuestRepository(QuestDbContext context)
        {
            _context = context;
        }
        public IQueryable<Instruction> Instructions => _context.Instructions;
        public IQueryable<Step> Steps => _context.Steps;
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public void UpdateContext() => _context.ChangeTracker.Entries()
            .ToList().ForEach(e => e.Reload());
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}