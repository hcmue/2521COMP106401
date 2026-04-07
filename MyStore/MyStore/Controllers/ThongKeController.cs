using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Entities;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly MyeStoreContext _context;

        public ThongKeController(MyeStoreContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ThongKeTheoLoai()
        {
            var data = _context.ChiTietHds
                .GroupBy(g => new
                {
                    g.MaHhNavigation.MaLoai,
                    g.MaHhNavigation.MaLoaiNavigation.TenLoai
                })
                .Select(g => new DoanhThuLoaiVM
                {
                    MaLoai = g.Key.MaLoai,
                    TenLoai = g.Key.TenLoai,
                    DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia * (1 - ct.GiamGia))
                }).ToList();
            return View(data);
        }

        [Authorize(Roles ="Sales")]
        public IActionResult ThongKeTheoHoaDon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThongKeHoaDon(DateTime TuNgay, DateTime DenNgay)
        {
            var data = _context.ChiTietHds
                .Where(ct => ct.MaHdNavigation.NgayDat >= TuNgay && ct.MaHdNavigation.NgayDat <= DenNgay)
                .GroupBy(g => new
                {
                    g.MaHhNavigation.MaLoai,
                    g.MaHhNavigation.MaLoaiNavigation.TenLoai
                })
                .Select(g => new DoanhThuLoaiVM
                {
                    MaLoai = g.Key.MaLoai,
                    TenLoai = g.Key.TenLoai,
                    DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia * (1 - ct.GiamGia))
                });
            return Json(data);
        }
    }
}
