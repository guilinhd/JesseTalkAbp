using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;


namespace LoanDemo.Customer.EntityFrameworkCore
{
    public class CustomerDbContext : AbpDbContext<CustomerDbContext> 
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Customers.Customer> Customers { get; set; }
    }
}
