using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSample.Customer.Application.Contracts.Dtos
{
    public class CustomerDto
    {
        public Guid Id { set; get; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string IdNo { get; set; }

        public List<LinkmanDto> Linkman { get; set; }
    }

    public class LinkmanDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdNo { get; set; }

    }
}
