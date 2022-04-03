using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using LoanSample.Customer.Application.Contracts.Dtos;

namespace LoanSample.Customer.Application.Contracts
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetListAsync();

        Task<CustomerDto> CreateAsync(CustomerDto customerDto);

        Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkman);
    }
}
