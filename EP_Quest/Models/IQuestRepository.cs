namespace EP_Quest.Models
{
    public interface IQuestRepository
    {
        IQueryable<CompletionTime> CompletionTimes { get; }
    }
}