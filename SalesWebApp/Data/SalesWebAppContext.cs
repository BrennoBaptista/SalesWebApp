using Microsoft.EntityFrameworkCore;

namespace SalesWebApp.Infra
{
    public class SalesWebAppContext : DbContext
    {
        public SalesWebAppContext(DbContextOptions<SalesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebApp.Models.Entities.Department> Department { get; set; }
    }
}
