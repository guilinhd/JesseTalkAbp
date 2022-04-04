using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDemo.Customer.Application.Contracts.Model.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string IdNo { get; set; }

        public List<LinkmanDto> linkmen { get; set; }

    }

    public class LinkmanDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdNo { get; set; }
    }
}
