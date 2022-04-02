using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Galaxy.Order.Contracts.Models.Dtos;
using Galaxy.Order.Contracts;
using System.Threading.Tasks;
using Galaxy.Product.Contracts;
using Galaxy.Product.Contracts.Models.Dtos;
using System.Threading;

namespace Galaxy.Order
{
    public class OrderService : ApplicationService, IOrderService
    {
        private IProductService productService { get; set; }

        public OrderService(IProductService productService)
        {
            this.productService = productService;
        }

        public Task<OrderDto> CreateAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var items = await this.productService.GetAllAsync(new ProductQueryDto());
            var task = await Task.Run(() =>
            {
                Thread.Sleep(100);
                return new OrderDto() { Id = id,  Products = items };
            });
            return task;
        }
    }
}
