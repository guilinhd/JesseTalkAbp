using Galaxy.Product.Contracts;
using Galaxy.Product.Contracts.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using System.Threading;
using System.Linq;

namespace Galaxy.Product
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly List<ProductDto> products;


        public ProductService()
        {
            products = new List<ProductDto>()
            {
                new ProductDto(){ Id = 1, Name = "Apple Phone"},
                new ProductDto(){Id = 2, Name = "IBM Note Book"}
            };
        }

        public Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync(ProductQueryDto query)
        {
            var task = Task.Run(() => {
                Thread.Sleep(1000);

                return products.AsEnumerable();
            });

            return task;
        }
    }
}
