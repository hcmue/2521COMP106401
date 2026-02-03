using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace DemoBuoi03.Controllers
{
    public class UploaderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile myfile)
        {
            if (myfile == null)
            {
                ViewBag.Message = "Chưa chọn file upload.";
            }
            else
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", myfile.FileName);
                using (var f = new FileStream(fullPath, FileMode.CreateNew))
                {
                    myfile.CopyTo(f);
                }
            }
            return View("Index");
        }

        public IActionResult UploadFiles(List<IFormFile> myfiles)
        {
            if (myfiles == null || myfiles.Count == 0)
            {
                ViewBag.Message = "Chưa chọn file upload.";
            }
            else
            {
                foreach (var myfile in myfiles)
                {
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", myfile.FileName);
                    using (var f = new FileStream(fullPath, FileMode.CreateNew))
                    {
                        myfile.CopyTo(f);
                    }
                }
            }
            return View("Index");
        }
    }
}
