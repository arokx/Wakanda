using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CounterQueue : BaseEntity
    {
        public int CounterId { get; set; }
        public Counter Counter { get; set; }
        public int TokenId { get; set; }
        public Token Token { get; set; }
    }
}
