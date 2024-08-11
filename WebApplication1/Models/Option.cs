
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

public class Option
{

    public int OptionId { get; set; }

    public string Text { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; }
}