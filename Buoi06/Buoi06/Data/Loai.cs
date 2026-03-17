using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi06.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [MaxLength(50)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        [MaxLength(150)]
        public string Hinh { get; set; }
        public ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
    }
}
