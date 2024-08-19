using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain;

namespace WebApplication2.Infrastructure.Persistence
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
