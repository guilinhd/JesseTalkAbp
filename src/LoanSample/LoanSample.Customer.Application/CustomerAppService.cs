using LoanSample.Customer.Application.Contracts;
using LoanSample.Customer.Application.Contracts.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LoanSample.Customer.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        public Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkman)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> CreateAsync(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
