using Galaxy.Product.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Http.Client;

namespace Galaxy.Order.API
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientModule),
        typeof(GalaxyOrderModule)
        )]
    public class GalaxyOrderApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //创建动态客户端代理
            context.Services.AddHttpClientProxies(
                typeof(GalaxyProductContractModule).Assembly, remoteServiceConfigurationName: "ProductStore"
            );

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
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
                
                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Order.Api");
                
                });

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Galaxy.Order.Api", Description = "V1.0" });
                options.DocInclusionPredicate((doc, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}
