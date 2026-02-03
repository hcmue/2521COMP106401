using DemoBuoi03.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace DemoBuoi03.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model, IFormFile Hinh)
        {
            if (Hinh != null)
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Hinh.FileName);
                using (var f = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(f);
                    model.Image = Hinh.FileName;
                }
            }
            return View("Profile", model);
        }


    }
}
