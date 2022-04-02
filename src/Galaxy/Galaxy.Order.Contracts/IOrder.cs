using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using System.Threading;
using System.Threading.Tasks;
using Galaxy.Order.Contracts.Models.Dtos;

namespace Galaxy.Order.Contracts
{
    public interface IOrder : IApplicationService
    {
        Task<OrderDto> CreateAsync(OrderDto orderDto);

        Task<OrderDto> FindAsync(int id);
    }
}
