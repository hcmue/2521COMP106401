using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationLab.Models;

namespace ValidationLab.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }

        public IActionResult CheckEmployeeNoExists(string employeeNo)
        {
            if (string.IsNullOrEmpty(employeeNo))
                return Json("Mã nhân viên là bắt buộc");

            //fake db
            var db = new List<string> { "NV0123", "admin" };
            var exists = db.Any(e => e == employeeNo);
            if (exists)
            {
                return Json("Mã nhân viên đã tồn tại");
            }

            return Json(true);
        }
    }
}
