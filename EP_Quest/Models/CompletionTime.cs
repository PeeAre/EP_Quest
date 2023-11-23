namespace EP_Quest.Models
{
    public class CompletionTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime EndTime { get; set; }
    }
}
