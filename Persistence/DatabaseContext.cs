using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Domain.Entities.ServiceProvider> ServiceProviders { get; set; }
        public DbSet<CounterQueue> CounterQueues { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
    }
}
