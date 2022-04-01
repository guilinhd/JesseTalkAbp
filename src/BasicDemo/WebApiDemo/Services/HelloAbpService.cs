using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WebApiDemo.Services
{
    public class HelloAbpService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("Hello Abp !");
        }
    }
}
