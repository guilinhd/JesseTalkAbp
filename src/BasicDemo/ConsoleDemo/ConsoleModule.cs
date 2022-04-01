using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using ConsoleDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDemo
{
    public class ConsoleModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddTransient<HelloAbpService>();

            base.ConfigureServices(context);
        }
    }
}
