using LoanDemo.Customer.Application.Contracts.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LoanDemo.Customer.Application.Contracts
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetAsync(Guid id);

        Task<List<CustomerDto>> GetListAsync();

        Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkmanDto);
    }
}
