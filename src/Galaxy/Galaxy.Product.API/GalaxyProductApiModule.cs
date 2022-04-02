using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Galaxy.Product;
using Volo.Abp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Galaxy.Product.API
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(GalaxyProductModule)
        )]
    public class GalaxyProductApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(GalaxyProductModule).Assembly);
            });

            context.Services.AddSwaggerGen(options=>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Galaxy.Product.API v1", Description = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Product.API v1"));
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
