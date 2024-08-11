using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }

        [Required]
        [Display(Name = "Sınav Adı")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Süre (Dakika)")]
        public int Duration { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Geçme Notu")]
        public int PassingScore { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int SelectedCategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
