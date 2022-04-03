using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using LoanSample.Customer.Application;
using Volo.Abp;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace LoanSample.Customer.API
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(AbpAutofacModule)
        )]

    //[DependsOn(typeof(LoanSampleCustomerApplicationModule))]

    public class LoanSampleCustomerAPIModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpAspNetCoreMvcOptions>(options => {
            //    options.ConventionalControllers.Create(typeof(LoanSampleCustomerApplicationModule).Assembly);
            //});

            ConfigureSwaggerServices(context.Services);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "LoanSample.Customer.API");
                });
            }

            app.UseRouting();
            
            
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "LoanSample.Customer.API", Description = "v1.0" });
                //options.DocInclusionPredicate((doc, description) => true);
                //options.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}
