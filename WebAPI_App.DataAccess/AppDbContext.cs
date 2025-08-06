using Microsoft.EntityFrameworkCore;
using WebAPI_App.Entities;
namespace WebAPI_App.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();

    }

}