
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoanDemo.Customer.EntityFrameworkCore
{

    [DependsOn(
        typeof(AbpEntityFrameworkCoreMySQLModule)
        )]
    public class LoanDemoCustomerEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CustomerDbContext>(options => {
                options.AddDefaultRepositories();
            });

            Configure<AbpDbContextOptions>(options => {
                options.UseMySQL();
            });
        }
    }
}
