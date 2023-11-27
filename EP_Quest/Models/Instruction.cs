using System.ComponentModel.DataAnnotations;

namespace EP_Quest.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
