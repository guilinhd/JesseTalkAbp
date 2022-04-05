using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using LoanDemo.Customer.Domain;
using Volo.Abp.Autofac;

namespace LoanDemo.Customer.Migrator
{
    [DependsOn(
        typeof(LoanDemoCustomerDomainModule),
        typeof(AbpAutofacModule)
        )]
    public class LoanDemoCustomerMigratorModule : AbpModule
    {
        
    }
}
