using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double SoHang01, double SoHang02, string ToanTu)
        {
            double KetQua = 0;
            switch(ToanTu)
            {
                case "+": KetQua = SoHang01 + SoHang02; break;
                case "^": KetQua = Math.Pow(SoHang01, SoHang02); break;
                case "%": KetQua = SoHang01 % SoHang02; break;
            }

            //truyền dữ liệu qua View Index.cshtml để hiển thị
            ViewBag.SoHang1 = SoHang01;
            ViewBag.SoHang2 = SoHang02;
            ViewBag.KetQua = KetQua;
            ViewBag.PhepToan = ToanTu;
            return View("Index");
        }
    }
}
