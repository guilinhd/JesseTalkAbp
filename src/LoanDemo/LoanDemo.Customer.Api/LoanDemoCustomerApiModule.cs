using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using LoanDemo.Customer.Application;

namespace LoanDemo.Customer.Api
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(LoanDemoCustomerApplicationModule)
        )]
    public class LoanDemoCustomerApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            //services.AddControllers();

            Configure<AbpAspNetCoreMvcOptions>(options => {
                options.ConventionalControllers.Create(typeof(LoanDemoCustomerApplicationModule).Assembly);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoanDemo.Customer.Api", Version = "v1" });
                c.DocInclusionPredicate((doc, description) => true);
                c.CustomSchemaIds(type => type.FullName);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoanDemo.Customer.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
