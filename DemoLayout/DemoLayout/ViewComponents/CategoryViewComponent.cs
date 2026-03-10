using DemoLayout.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoLayout.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //đọc database
            var danhMuc = new List<Category>
            {
                new Category{Id=1, Name="Điện thoại"},
                new Category{Id=2, Name="Máy tính bảng"},
                new Category{Id=3, Name="Điều hòa"},
            };
            return View(danhMuc);
        }
    }
}
