using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ExamController : Controller
    {
        private readonly AppDbContext _context;

        public ExamController(AppDbContext context)
        {
            _context = context;
        }

   
        public IActionResult Create()
        {
            var viewModel = new ExamViewModel
            {
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam
                {
                    Name = viewModel.Name,
                    Duration = viewModel.Duration,
                    Description = viewModel.Description,
                    PassingScore = viewModel.PassingScore,
                    CategoryId = viewModel.SelectedCategoryId
                };

                _context.Exams.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

         
            viewModel.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList();

            return View(viewModel);
        }


    }
}
