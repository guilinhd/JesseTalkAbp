using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using LoanDemo.Customer.EntityFrameworkCore;


namespace LoanDemo.Customer.EntityFrameworkCore.Migration
{
    [DependsOn(typeof(LoanDemoCustomerEntityFrameworkCoreModule))]
    public class LoanDemoCustomerEntityFrameworkCoreMigrationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CustomerMigrationDbContext>();
        }
    }
}
