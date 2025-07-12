using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DogWalkerApp.Infrastructure.Data
{
    public class DogWalkerDbContextFactory : IDesignTimeDbContextFactory<DogWalkerDbContext>
    {
        public DogWalkerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DogWalkerDbContext>();
            optionsBuilder.UseSqlite("Data Source=dogwalker.db");

            return new DogWalkerDbContext(optionsBuilder.Options);
        }
    }
}
