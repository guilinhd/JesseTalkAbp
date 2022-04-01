using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;

namespace WebApiDemo
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class WebApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddControllers();

            //base.ConfigureServices(context);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
