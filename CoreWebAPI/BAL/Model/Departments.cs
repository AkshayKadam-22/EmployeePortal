using System.ComponentModel.DataAnnotations;

namespace CoreWebAPI.BAL.Model
{
    public class Departments
    {

        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
