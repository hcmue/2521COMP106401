using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyStore.Entities;
using MyStore.Models;
using System.Security.Claims;

namespace MyStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public AccountController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string ReturnUrl = null)
        {
            var kh = _ctx.KhachHangs.SingleOrDefault(p => p.MaKh == model.Username && p.MatKhau == model.Password);
            if (kh == null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                ViewBag.Message = "Sai thông tin Đăng nhập";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, kh.Email),
                new Claim(ClaimTypes.Name, kh.HoTen),
                new Claim("CustomerId", kh.MaKh),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieAuth", principal);
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login");
        }



        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
