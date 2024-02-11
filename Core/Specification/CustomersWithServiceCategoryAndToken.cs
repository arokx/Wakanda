using Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{

    public class CustomersWithServiceCategoryAndToken : BaseSpecification<Customer>
    {
        public CustomersWithServiceCategoryAndToken() : base()
        {
            AddInclude(x => x.ServiceCategory);
            AddInclude(x => x.Token);
        }
    }

}
