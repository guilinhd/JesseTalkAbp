using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using LoanDemo.Customer.Domain.Data;

namespace LoanDemo.Customer.Migrator
{
    public class DbMigratorHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var application = AbpApplicationFactory.Create<LoanDemoCustomerMigratorModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            });
            application.Initialize();

            await application
                .ServiceProvider
                .GetRequiredService<CustomerStoreMigrationService>()
                .MigrateAsync();

            application.Shutdown();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
