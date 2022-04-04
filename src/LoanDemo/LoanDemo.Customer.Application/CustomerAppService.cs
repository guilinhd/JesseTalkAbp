using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LoanDemo.Customer.Application
{
    public class CustomerAppService : ApplicationService
    {
        public string GetAsync()
        {
            return "Hello Abp !";
        }
    }
}
