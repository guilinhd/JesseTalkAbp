using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDemo.Customer.Domain.Data
{
    public interface ICustomerStoreSchemaMigrator
    {
        Task MigratorAsync();
    }
}
