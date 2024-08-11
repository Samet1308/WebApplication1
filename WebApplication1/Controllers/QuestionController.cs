using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Text = viewModel.Text
                };

    
                for (int i = 0; i < viewModel.OptionTexts.Count; i++)
                {
                    var option = new Option
                    {
                        Text = viewModel.OptionTexts[i],
                        Question = question
                    };
                    question.Options.Add(option);

            
                    if (i == viewModel.CorrectOptionIndex)
                    {
                        question.CorrectOption = option;
                    }
                }

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin");
            }

            return View(viewModel);
        }
    }
}
