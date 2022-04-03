using LoanSample.Customer.Application.Contracts;
using LoanSample.Customer.Application.Contracts.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
using Volo.Abp.Uow;

namespace LoanSample.Customer.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly IRepository<Domain.Customers.Customer> _repository;
        private readonly IUnitOfWorkManager _unitOfWork;

        public CustomerAppService(IRepository<Domain.Customers.Customer> repository, IUnitOfWorkManager unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> AddLinkman(Guid customerId, LinkmanDto linkmanDto)
        {
            Domain.Customers.Customer customer = await _repository.GetAsync(c => c.Id == customerId);
            Domain.Customers.Linkman linkman = ObjectMapper.Map<LinkmanDto, Domain.Customers.Linkman>(linkmanDto);
            customer.AddLinkman(linkman);

            using (var uow = _unitOfWork.Begin())
            {
                var result = await _repository.UpdateAsync(customer);
                await uow.CompleteAsync();

                return ObjectMapper.Map<Domain.Customers.Customer, CustomerDto>(customer);
            }
            
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto customerDto)
        {
            Domain.Customers.Customer customer = ObjectMapper.Map<CustomerDto, Domain.Customers.Customer>(customerDto);

            var result = await _repository.InsertAsync(customer);

            return ObjectMapper.Map<Domain.Customers.Customer, CustomerDto>(result);
        }

        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customers = await _repository.GetListAsync();
            return ObjectMapper.Map<List<Domain.Customers.Customer>, List<CustomerDto>>(customers);
        }
    }
}
