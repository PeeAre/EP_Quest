namespace EP_Quest.Models
{
    public interface IQuestRepository : IDisposable
    {
        IQueryable<Instruction> Instructions { get; }
        IQueryable<Step> Steps { get; }
        void UpdateContext();
        Task SaveChangesAsync();
    }
}