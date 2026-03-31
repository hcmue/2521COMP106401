using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class DoanhThuLoaiVM
    {
        [Key]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public double DoanhThu { get; set; }
    }
}
