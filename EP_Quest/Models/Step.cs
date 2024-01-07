using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP_Quest.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public DateTime? Start { get; set; } = null;
        [Required]
        [Column(TypeName = "interval")]
        public TimeSpan Duration { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public bool IsLocked { get; set; } = true;
        [Required]
        public bool IsDone { get; set; } = false;
        [Required]
        public bool IsCurrent { get; set; } = false;
    }
}
