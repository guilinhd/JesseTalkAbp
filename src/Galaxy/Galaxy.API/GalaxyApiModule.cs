using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Galaxy.Order;
using Galaxy.Product;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Galaxy.API
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(GalaxyOrderModule), typeof(GalaxyProductModule))]
    public class GalaxyApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options => {

                options.ConventionalControllers.Create(typeof(GalaxyProductModule).Assembly);
                options.ConventionalControllers.Create(typeof(GalaxyOrderModule).Assembly);
            });

            ConfigureSwaggerServices(context.Services);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy API");
                
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Galaxy API", Version = "v1.0" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
    }
}
