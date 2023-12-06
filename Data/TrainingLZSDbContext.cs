using Microsoft.EntityFrameworkCore;
using TrainingLZS.Models;

namespace TrainingLZS.Data
{
    public class TrainingLZSDbContext : DbContext
    {
        public TrainingLZSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
