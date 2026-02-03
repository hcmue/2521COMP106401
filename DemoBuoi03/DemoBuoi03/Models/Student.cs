using System.ComponentModel.DataAnnotations;

namespace DemoBuoi03.Models
{
    public class Student
    {
        [RegularExpression(@"\d{2}.01.104.\d{3}")]
        public string Id { get; set; }

        [MinLength(5, ErrorMessage ="Tối thiểu 5 kí tự")]
        public string Name { get; set; }
        public string? Image { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm từ 0 .. 10")]
        public double Score { get; set; }
    }
}
