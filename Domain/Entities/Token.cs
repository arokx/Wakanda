using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token : BaseEntity
    {
        public DateTime IssuedTime { get; set; }
        public int ResolutionId { get; set; }
        public Resolution Resolution { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
