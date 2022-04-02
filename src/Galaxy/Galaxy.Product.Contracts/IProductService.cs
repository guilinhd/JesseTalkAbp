using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using System.Threading;
using System.Threading.Tasks;
using Galaxy.Product.Contracts.Models.Dtos;

namespace Galaxy.Product.Contracts
{
    public interface IProductService : IApplicationService
    {
        Task<ProductDto> CreateAsync(ProductDto productDto);

        Task<IEnumerable<ProductDto>> GetAllAsync(ProductQueryDto query);
    }
}
