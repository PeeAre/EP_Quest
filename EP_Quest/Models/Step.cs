using System.ComponentModel.DataAnnotations;

namespace EP_Quest.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsLocked { get; set; } = true;
        public CompletionTime? CompletionTime { get; set; }

    }
}
