using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace vebtech_test.DAL.DateDbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VebtechDbContext>
    {
        public VebtechDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<VebtechDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("MyDbConnection"));

            return new VebtechDbContext(builder.Options);
        }
    }
}
