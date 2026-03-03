using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ValidationLab.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Display(Name = "Mã nhân viên")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Từ 5 .. 20 kí tự")]
        [Remote("CheckEmployeeNoExists", "Employee")]
        public string EmployeeNo { get; set; }

        [MaxLength(100, ErrorMessage ="Tối đa 100 kí tự")]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Url]
        public string? Website { get; set; }

        [DataType(DataType.Date)]
        [BirthDateCheck]
        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        [Range(0, double.MaxValue)]
        public double Salary { get; set; }

        public bool IsPartTime { get; set; }

        public string? Address { get; set; }

        [RegularExpression("0[35789][0-9]{8}")]
        public string Phone { get; set; }


        [CreditCard]
        public string? CreditCard { get; set; }


        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage ="Tối đa 255 kí tự")]
        public string Description { get; set; }
    }
}
