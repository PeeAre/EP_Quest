namespace EP_Quest.Models
{
    public interface IQuestRepository
    {
        IQueryable<CompletionTime> CompletionTimes { get; }
        IQueryable<Instruction> Instructions { get; }
        IQueryable<Step> Steps { get; }
    }
}