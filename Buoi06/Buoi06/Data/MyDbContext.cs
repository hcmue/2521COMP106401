using Microsoft.EntityFrameworkCore;

namespace Buoi06.Data
{
    public class MyDbContext : DbContext
    {
        //1 Hàm tạo
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        //2 Khai báo các DbSet <--> table
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
    }
}
