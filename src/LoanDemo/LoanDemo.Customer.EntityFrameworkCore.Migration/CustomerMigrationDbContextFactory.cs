using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LoanDemo.Customer.EntityFrameworkCore.Migration
{
    public class CustomerMigrationDbContextFactory : IDesignTimeDbContextFactory<CustomerMigrationDbContext>
    {
        public CustomerMigrationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CustomerMigrationDbContext>()
                .UseMySql(configuration.GetConnectionString("CustomerConnString"), null);

            return new CustomerMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
