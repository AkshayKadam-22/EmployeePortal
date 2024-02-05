using CoreWebAPI.BAL.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.BAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Department { get; set; }
    }
}
