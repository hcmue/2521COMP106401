namespace MyStore.Models
{
    public class HangHoaVM
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; } = null!;
        public string Hinh { get; set; } = null!;
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
        public string TenNCC { get; set; }
    }
}
