using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using LoanSample.Customer.Domain;
using LoanSample.Customer.Application.Contracts;
using Volo.Abp.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LoanSample.Customer.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule)
        )]

    [DependsOn(
        typeof(LoanSampleDomainModule),
        typeof(LoanSampleCustomerApplicationContractsModule)
        )]
    public class LoanSampleCustomerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddAutoMapperObjectMapper<LoanSampleCustomerApplicationModule>();

            Configure<AbpAutoMapperOptions>(options => {
                options.AddMaps<LoanSampleCustomerApplicationModule>();
            });
        }
    }
}
