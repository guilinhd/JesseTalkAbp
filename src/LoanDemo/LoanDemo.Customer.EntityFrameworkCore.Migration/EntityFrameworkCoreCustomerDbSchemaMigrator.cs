
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using LoanDemo.Customer.Domain.Data;

namespace LoanDemo.Customer.EntityFrameworkCore.Migration
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(ICustomerStoreSchemaMigrator))]
    public class EntityFrameworkCoreCustomerDbSchemaMigrator : ICustomerStoreSchemaMigrator
    {
        private readonly CustomerMigrationDbContext _dbContext;
        public EntityFrameworkCoreCustomerDbSchemaMigrator(CustomerMigrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigratorAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
