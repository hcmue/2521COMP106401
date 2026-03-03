using System.ComponentModel.DataAnnotations;

namespace ValidationLab.Models
{
    public class BirthDateCheckAttribute : ValidationAttribute
    {
        public BirthDateCheckAttribute() : base("Ngày sinh chưa hợp lệ") { }

        //public override bool IsValid(object? value)
        //{
        //    return base.IsValid(value);
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // 1. Ngày sinh bắt buộc
            if (value == null)
            {
                return new ValidationResult("Phải nhập ngày sinh");
            }

            // 2. Tuổi >= 18 (DateTime.Now.Year - BirthDate.Year >= 10)
            var BirthDate = (DateTime)value;

            if (DateTime.Now.Year - BirthDate.Year >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Chưa đủ 18 tuổi");
            }
        }
    }
}