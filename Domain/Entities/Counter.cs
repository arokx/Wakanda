using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Counter:BaseEntity
    {
        public int CounterNumber { get; set; }
        public int ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public List<CounterQueue> CounterQueues { get; set; }
    }
}
