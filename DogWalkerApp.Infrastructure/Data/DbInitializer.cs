using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Data;

public static class DbInitializer
{
    
        public static void Seed(DogWalkerDbContext context)
        {
            // Agrega AppConfigurations si no existen
            if (!context.AppConfigurations.Any())
            {
                context.AppConfigurations.AddRange(new[]
                {
                new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Maximum number of dogs per walk" },
                new AppConfiguration { Key = "DefaultWalkTime", Value = "30", Description = "Default walk duration in minutes" }
            });
            }

            if (!context.Walkers.Any())
            {
                var walkers = new[]
                {
                new Walker { FullName = "Michael Torres", PhoneNumber = "+1 305-555-1001", IsAvailable = true },
                new Walker { FullName = "Sarah Mitchell", PhoneNumber = "+1 786-555-2045", IsAvailable = true },
                new Walker { FullName = "Jason Rivera", PhoneNumber = "+1 305-555-3322", IsAvailable = true },
                new Walker { FullName = "Olivia Thompson", PhoneNumber = "+1 786-555-4987", IsAvailable = true }
            };
                context.Walkers.AddRange(walkers);
            }

            if (!context.Clients.Any())
            {
                var clients = new[]
                {
                new Client
                {
                    Name = "John Smith",
                    PhoneNumber = "+1 305-555-1234",
                    Address = "123 Biscayne Blvd, Miami, FL",
                    Subscription = new Subscription
                    {
                        Frequency = SubscriptionFrequency.Monthly,
                        MaxDogsAllowed = 2,
                        IsActive = true,
                        Payments = new List<Payment>
                        {
                            new Payment { Date = DateTime.UtcNow, Amount = 30.00m, Method = PaymentMethod.Card }
                        }
                    }
                },
                new Client
                {
                    Name = "Emily Johnson",
                    PhoneNumber = "+1 786-555-6789",
                    Address = "456 Coral Way, Miami, FL",
                    Subscription = new Subscription
                    {
                        Frequency = SubscriptionFrequency.Monthly,
                        MaxDogsAllowed = 1,
                        IsActive = true,
                        Payments = new List<Payment>
                        {
                            new Payment { Date = DateTime.UtcNow, Amount = 30.00m, Method = PaymentMethod.Cash }
                        }
                    }
                },
                new Client
                {
                    Name = "Robert Davis",
                    PhoneNumber = "+1 305-555-7788",
                    Address = "789 Sunset Dr, Miami, FL",
                    Subscription = new Subscription
                    {
                        Frequency = SubscriptionFrequency.Monthly,
                        MaxDogsAllowed = 2,
                        IsActive = false,
                        Payments = new List<Payment>
                        {
                            new Payment { Date = DateTime.UtcNow.AddDays(-35), Amount = 30.00m, Method = PaymentMethod.Cash }
                        }
                    }
                }
            };

                context.Clients.AddRange(clients);
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(new[]
                {
                new User { Username = "admin", Password = "1234" },
                new User { Username = "demo", Password = "demo" }
            });
            }

            context.SaveChanges();
        }
    
}
