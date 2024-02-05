using System.ComponentModel.DataAnnotations;

namespace CoreWebAPI.BAL.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Employeename { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
