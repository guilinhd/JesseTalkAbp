using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LoanDemo.Customer.Domain.Data
{
    public class CustomerStoreMigrationService : ITransientDependency
    {
        private readonly ICustomerStoreSchemaMigrator _dbSchemaMigrator;
        public ILogger<CustomerStoreMigrationService> Logger { get; set; }

        public CustomerStoreMigrationService(ICustomerStoreSchemaMigrator dbSchemaMigrator)
        {
            _dbSchemaMigrator = dbSchemaMigrator;
        }

        public async Task MigratorAsync()
        {

            Logger.LogInformation("Started database migrations...");
            Logger.LogInformation("Migrating database schema...");

            await _dbSchemaMigrator.MigratorAsync();

            Logger.LogInformation("Successfully completed database migrations.");
        }
    }
}
