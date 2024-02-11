using Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class CustomerGroupByCategory : BaseSpecification<Customer>
    {
        public CustomerGroupByCategory() :base()
        {
            AddInclude(x => x.ServiceCategory);
            ApplyGroupBy(x => x.ServiceCategory);
        }
    }
}
