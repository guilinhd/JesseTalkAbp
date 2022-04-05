using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LoanDemo.Customer.EntityFrameworkCore.Migration
{
    [ConnectionStringName("CustomerConnString")]
    public class CustomerMigrationDbContext : AbpDbContext<CustomerMigrationDbContext>
    {
        public CustomerMigrationDbContext(DbContextOptions<CustomerMigrationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */
            builder.ConfigureCustomerStore();
        }
    }
}
