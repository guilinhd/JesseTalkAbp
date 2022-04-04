using LoanDemo.Customer.Application.Contracts;
using LoanDemo.Customer.Application.Contracts.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LoanDemo.Customer.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        public Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkmanDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
