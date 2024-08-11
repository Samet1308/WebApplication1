using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Question
    {
   
        public int Id { get; set; }

        public string Text { get; set; }

        public List<Option> Options { get; set; } = new List<Option>();

        public int CorrectOptionId { get; set; }

        public virtual Option CorrectOption { get; set; }

    }

}
