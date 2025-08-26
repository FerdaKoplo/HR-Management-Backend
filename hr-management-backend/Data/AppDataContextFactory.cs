using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace hr_management_backend.Data
{
    public class AppDataContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDataContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=HRDB;User=root;Password=;",
                new MySqlServerVersion(new Version(8, 0, 33))
            );

            return new AppDataContext(optionsBuilder.Options);
        }
    }
}
