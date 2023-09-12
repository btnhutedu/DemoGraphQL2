using DemoGraphQL2.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
