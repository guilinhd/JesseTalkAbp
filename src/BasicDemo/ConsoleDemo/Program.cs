using System;
using Volo.Abp;
using Microsoft.Extensions.DependencyInjection;
using ConsoleDemo.Services;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<ConsoleModule>())
            {

                application.Initialize();

                var helloAbpService = application.ServiceProvider.GetRequiredService<HelloAbpService>();
                helloAbpService.SayHello();

                application.Shutdown();
            }

        }
    }
}
