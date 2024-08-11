using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {

        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string adminEmail = "admin@test.com";
            string adminPassword = "12345";

            if (email == adminEmail && password == adminPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminEmail),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "AdminLogin");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(principal);


                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz email veya şifre!";
                return View();
            }
        }

        public async Task<IActionResult> Index()
        {
           
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

