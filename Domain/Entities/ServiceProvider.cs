using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceProvider : BaseEntity
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public List<Counter> Counters { get; set; }
    }
}
