using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int PassingScore { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
