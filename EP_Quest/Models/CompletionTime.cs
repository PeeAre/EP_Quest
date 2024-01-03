using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP_Quest.Models
{
    public class CompletionTime
    {
        [ForeignKey("Step")]
        public int Id { get; set; }
        public DateTime Start { get; set; } = DateTime.Now.ToUniversalTime();
        [Required]
        public DateTime Duration { get; set; }
    }
}
