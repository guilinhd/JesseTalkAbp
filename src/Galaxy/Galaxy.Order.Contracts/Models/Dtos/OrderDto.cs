using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Product.Contracts.Models.Dtos;

namespace Galaxy.Order.Contracts.Models.Dtos
{
    public class OrderDto
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public IEnumerable<ProductDto> Products { set; get; }
    }
}
