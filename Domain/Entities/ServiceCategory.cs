using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<Customer> Customers { get; set; }
    }

}
