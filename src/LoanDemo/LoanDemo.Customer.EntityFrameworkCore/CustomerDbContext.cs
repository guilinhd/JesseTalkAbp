using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;


namespace LoanDemo.Customer.EntityFrameworkCore
{
    [ConnectionStringName("CustomerConnString")]
    public class CustomerDbContext : AbpDbContext<CustomerDbContext> 
    {
        public DbSet<Domain.Customers.Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCustomerStore();
        }
    }
}
