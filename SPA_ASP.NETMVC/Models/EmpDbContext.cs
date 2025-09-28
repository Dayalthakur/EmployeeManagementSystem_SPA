using Microsoft.EntityFrameworkCore;

namespace SPA_ASP.NETMVC.Models
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get;set; }
    }
}
