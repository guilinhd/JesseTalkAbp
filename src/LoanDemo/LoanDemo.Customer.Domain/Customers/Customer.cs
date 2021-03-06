using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LoanDemo.Customer.Domain.Customers
{
    public class Customer : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string IdNo { get; set; }

        private List<Linkman> _linkmen = new List<Linkman>();
        public ReadOnlyCollection<Linkman> Linkmen()
        {
            return _linkmen.AsReadOnly();
        }

        public void AddLinkman(Linkman linkman)
        {
            _linkmen.Add(linkman);
        }
    }

    public class Linkman : Entity<Guid>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdNo { get; set; }
    }
}
