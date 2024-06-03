using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Internet_Programlama_Final_Work.Models;
using Internet_Programlama_Final_Work.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Internet_Programlama_Final_Work.Controllers
{
    public class StartpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartpController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Logincs logincs)
        {
            // Veritabanında kullanıcıyı bulma
            var user = await _context.Logincs.FirstOrDefaultAsync(u => u.Email == logincs.Email && u.PassWord == logincs.PassWord);
            if (user != null)
            {
                // Kullanıcı doğrulandıysa, giriş yap
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, logincs.Email),
                    new Claim("DiğerÖzellikler", "Örnek Rol")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = logincs.LoggedStatus
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Home");
            }

            ViewData["OnayMesaji"] = "Kullanıcı Bulunamadı";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Kullanıcı zaten giriş yapmışsa anasayfaya yönlendir
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(new Logincs());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var logincs = new Logincs
                {
                    Email = viewModel.Email,
                    PassWord = viewModel.Password,
                    LoggedStatus = viewModel.LoggedStatus
                };

                _context.Logincs.Add(logincs);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(viewModel);
        }

    }
}
