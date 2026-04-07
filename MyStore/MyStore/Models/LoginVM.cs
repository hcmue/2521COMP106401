using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class LoginVM
    {
        [Key]
        [MaxLength(20)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
