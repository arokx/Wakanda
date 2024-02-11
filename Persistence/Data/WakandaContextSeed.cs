using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Text.Json;

namespace Infrastructure.Persistence.Data
{
    public class WakandaContextSeed
    {
        public static async Task SeedAsync(DatabaseContext context)
        {
            if (!context.ServiceCategories.Any())
            {

                using var transaction = context.Database.BeginTransaction();
                var serviceCategoryData = File.ReadAllText("../Persistence/Data/SeedData/ServiceCategories.json");
                var categories = JsonSerializer.Deserialize<List<ServiceCategory>>(serviceCategoryData); ;

                foreach (var item in categories)
                {
                    context.ServiceCategories.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceCategories ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceCategories OFF");
                transaction.Commit();

            }

            if (!context.Resolutions.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var resolutionsData = File.ReadAllText("../Persistence/Data/SeedData/Resolution.json");
                var resolutions = JsonSerializer.Deserialize<List<Resolution>>(resolutionsData);
                foreach (var item in resolutions)
                {
                    context.Resolutions.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Resolutions ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Resolutions OFF");
                transaction.Commit();
            }

            if (!context.ServiceProviders.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var serviceProvidersData = File.ReadAllText("../Persistence/Data/SeedData/ServiceProviders.json");
                var serviceProviders = JsonSerializer.Deserialize<List<Domain.Entities.ServiceProvider>>(serviceProvidersData);

                foreach (var item in serviceProviders)
                {
                    context.ServiceProviders.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceProviders ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceProviders OFF");
                transaction.Commit();
            }

            if (!context.Customers.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var customersData = File.ReadAllText("../Persistence/Data/SeedData/Customers.json");
                var customers = JsonSerializer.Deserialize<List<Customer>>(customersData);

                foreach (var item in customers)
                {
                    context.Customers.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers OFF");
                transaction.Commit();
            }
        

            if (!context.Tokens.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var tokenData = File.ReadAllText("../Persistence/Data/SeedData/Tokens.json");
                var tokens = JsonSerializer.Deserialize<List<Token>>(tokenData);

                foreach (var item in tokens)
                {
                    context.Tokens.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tokens ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tokens OFF");
                transaction.Commit();
            }

            if (!context.Counters.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var countersData = File.ReadAllText("../Persistence/Data/SeedData/Counter.json");
                var counters = JsonSerializer.Deserialize<List<Counter>>(countersData);
                foreach (var item in counters)
                {
                    context.Counters.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Counters ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Counters OFF");
                transaction.Commit();
            }

            if (!context.CounterQueues.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var counterQueuesData = File.ReadAllText("../Persistence/Data/SeedData/CounterQueues.json");
                var counterQueues = JsonSerializer.Deserialize<List<CounterQueue>>(counterQueuesData);
                foreach (var item in counterQueues)
                {
                    context.CounterQueues.Add(item);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CounterQueues ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CounterQueues OFF");
                transaction.Commit();
            }

          

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
