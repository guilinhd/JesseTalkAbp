using LoanDemo.Customer.Application.Contracts.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDemo.Customer.Application.Profile
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
