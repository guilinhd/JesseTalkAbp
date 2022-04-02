using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Galaxy.Order;
using Galaxy.Product;

namespace Galaxy.API
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(AbpAutofacModule)
    )]
    [DependsOn(
        typeof(GalaxProductModule),
        typeof(GalaxOrderModule)
    )]

    public class GalaxyApiModule : AbpModule
    {
    }
}
