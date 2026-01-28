using Lab01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>
        {
            new Product{Id=1, Name = "Bún Bò", Price = 39000},
            new Product{Id=2, Name = "7 up", Price = 10900},
            new Product{Id=3, Name = "Bánh canh", Price = 39000},
        };

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            var product = products.SingleOrDefault(p => p.Id == model.Id);
            if (product == null)
            {
                products.Add(model);

                //lưu file
                var json = System.Text.Json.JsonSerializer.Serialize(products);
                System.IO.File.WriteAllText("Product.json", json);
                return RedirectToAction("Index");
            }
            ViewBag.Message = $"Mã {model.Id} đã có.";
            return View(model);
        }
    }
}
