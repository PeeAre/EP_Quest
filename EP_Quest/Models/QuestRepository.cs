namespace EP_Quest.Models
{
    public class QuestRepository : IQuestRepository
    {
        private QuestDbContext context;
        public QuestRepository(QuestDbContext context)
        {
            this.context = context;
        }
        public IQueryable<CompletionTime> CompletionTimes => context.CompletionTimes;
        public IQueryable<Instruction> Instructions => context.Instructions;
        public IQueryable<Step> Steps => context.Steps;
    }
}