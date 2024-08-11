using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class QuestionViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public List<string> OptionTexts { get; set; } = new List<string>(); 

        [Required]
        public int CorrectOptionIndex { get; set; }
    }
}
