using System.ComponentModel.DataAnnotations;

namespace ValidationLab.Models
{
    public class Person
    {
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="Phải nhập")]
        [MinLength(5, ErrorMessage ="Tối thiểu 5 kí tự")]
        public string FullName { get; set; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Phải nhập")]
        [Range(18, 62, ErrorMessage ="Tuổi 18 - 62")]
        public int Age { get; set; }
    }
}
