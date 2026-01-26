using Microsoft.EntityFrameworkCore;
using CarEntity = Car.Core.Entities.Car;

namespace Car.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CarEntity> Cars => Set<CarEntity>();
    }
}
