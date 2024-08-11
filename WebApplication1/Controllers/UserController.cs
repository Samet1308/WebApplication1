using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

      
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string name, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("UserId", user.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, "UserLogin");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre!";
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
