using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using LoanDemo.Customer.Application.Contracts;
using LoanDemo.Customer.Domain;

namespace LoanDemo.Customer.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule)
        )]

    [DependsOn(
        typeof(LoanDemoCustomerDomainModule),
        typeof(LoanDemoCustomerApplicationContractsModule)
        )]
    public class LoanDemoCustomerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddAutoMapperObjectMapper<LoanDemoCustomerApplicationModule>();

            Configure<AbpAutoMapperOptions>(options => {
                options.AddMaps<LoanDemoCustomerApplicationModule>();
            });
        }
    }
}
