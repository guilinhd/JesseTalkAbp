using LoanSample.Customer.Application.Contracts.Dtos;

namespace LoanSample.Customer.Application.Profile
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Domain.Customers.Customer>().ReverseMap();
            CreateMap<Domain.Customers.Customer, CustomerDto>().ReverseMap();

            CreateMap<LinkmanDto, Domain.Customers.Linkman>().ReverseMap();
            CreateMap<Domain.Customers.Linkman, LinkmanDto>().ReverseMap();
        }
    }
}
