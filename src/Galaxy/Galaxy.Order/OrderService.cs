using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Galaxy.Order.Contracts.Models.Dtos;
using Galaxy.Order.Contracts;
using System.Threading.Tasks;

namespace Galaxy.Order
{
    public class OrderService : ApplicationService, IOrderService
    {
        public Task<OrderDto> CreateAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
