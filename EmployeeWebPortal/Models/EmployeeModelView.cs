using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetMVCCore.Models
{
    public class EmployeeModelView
    {
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string? Employeename { get; set; }

        [Required]
        [DisplayName("Mobile No")]
        public string? MobileNo { get; set; }

        [Required]
        [DisplayName("Email Id")]
        public string? EmailId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
