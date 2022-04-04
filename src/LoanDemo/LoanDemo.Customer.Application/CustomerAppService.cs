using LoanDemo.Customer.Application.Contracts;
using LoanDemo.Customer.Application.Contracts.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace LoanDemo.Customer.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly IRepository<Domain.Customers.Customer> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public async Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkmanDto)
        {
            var linkman = ObjectMapper.Map<LinkmanDto, Domain.Customers.Linkman>(linkmanDto);

            var customer = await _repository.GetAsync(c => c.Id == customerId);
            customer.AddLinkman(linkman);

            using (var unitWork = _unitOfWorkManager.Begin())
            {
                var result = await _repository.UpdateAsync(customer);
                await unitWork.CompleteAsync();

                return ObjectMapper.Map<Domain.Customers.Customer, CustomerDto>(result);
            }
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _repository.GetAsync(c => c.Id == id);

            return ObjectMapper.Map<Domain.Customers.Customer, CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customers = await _repository.GetListAsync();

            return ObjectMapper.Map<List<Domain.Customers.Customer>, List<CustomerDto>>(customers);
        }
    }
}
