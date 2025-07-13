using Xunit;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DogWalkerApp.Tests.Services
{
    public class SubscriptionServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Create_ShouldAddSubscription()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Alatar", PhoneNumber = "101", Address = "Blue Mountains" };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new SubscriptionService(context);
            var dto = new SubscriptionDto
            {
                Frequency = SubscriptionFrequency.Monthly,
                MaxDogsAllowed = 2,
                IsActive = true,
                ClientId = client.Id
            };

            service.Create(dto);

            var result = context.Subscriptions.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(SubscriptionFrequency.Monthly, result.Frequency);
        }

        [Fact]
        public void GetAll_ShouldReturnOnlyNonDeletedSubscriptions()
        {
            // Arrange
            var context = GetInMemoryDbContext();

            var client1 = new Client
            {
                Name = "Balin",
                PhoneNumber = "202",
                Address = "Moria"
            };

            var client2 = new Client
            {
                Name = "Bofur",
                PhoneNumber = "203",
                Address = "Blue Mountains"
            };

            context.Clients.AddRange(client1, client2);
            context.SaveChanges();

            context.Subscriptions.AddRange(
                new Subscription
                {
                    Client = client1,
                    IsDeleted = false,
                    Frequency = SubscriptionFrequency.Monthly,
                    MaxDogsAllowed = 2,
                    IsActive = true
                },
                new Subscription
                {
                    Client = client2,
                    IsDeleted = true,
                    Frequency = SubscriptionFrequency.Weekly,
                    MaxDogsAllowed = 1,
                    IsActive = false
                }
            );
            context.SaveChanges();

            // Act
            var service = new SubscriptionService(context);
            var result = service.GetAll().ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Balin", result.First().ClientName);
        }



        [Fact]
        public void GetById_ShouldReturnNull_WhenDeleted()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Cirdan", PhoneNumber = "303", Address = "Havens" };
            var sub = new Subscription { Client = client, IsDeleted = true };
            context.AddRange(client, sub);
            context.SaveChanges();

            var service = new SubscriptionService(context);
            var result = service.GetById(sub.Id);

            Assert.Null(result);
        }

        [Fact]
        public void Update_ShouldModifySubscription()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Dain", PhoneNumber = "404", Address = "Iron Hills" };
            var sub = new Subscription
            {
                Client = client,
                Frequency = SubscriptionFrequency.Weekly,
                MaxDogsAllowed = 1,
                IsActive = false
            };
            context.AddRange(client, sub);
            context.SaveChanges();

            var service = new SubscriptionService(context);
            var dto = new SubscriptionDto
            {
                Id = sub.Id,
                Frequency = SubscriptionFrequency.Yearly,
                MaxDogsAllowed = 3,
                IsActive = true,
                ClientId = client.Id
            };

            service.Update(dto);

            var updated = context.Subscriptions.Find(sub.Id);
            Assert.Equal(SubscriptionFrequency.Yearly, updated.Frequency);
            Assert.Equal(3, updated.MaxDogsAllowed);
            Assert.True(updated.IsActive);
        }

        [Fact]
        public void Update_ShouldDoNothing_IfSubscriptionIsDeleted()
        {
            var context = GetInMemoryDbContext();

            var client1 = new Client { Name = "Eomer", PhoneNumber = "505", Address = "Rohan" };
            var client2 = new Client { Name = "Theoden", PhoneNumber = "506", Address = "Rohan" };
            context.Clients.AddRange(client1, client2);
            context.SaveChanges();

            var sub = new Subscription
            {
                Client = client1,
                Frequency = SubscriptionFrequency.Weekly,
                MaxDogsAllowed = 2,
                IsActive = false,
                IsDeleted = true
            };
            context.Subscriptions.Add(sub);
            context.SaveChanges();

            var service = new SubscriptionService(context);
            var dto = new SubscriptionDto
            {
                Id = sub.Id,
                Frequency = SubscriptionFrequency.Monthly,
                MaxDogsAllowed = 5,
                IsActive = true,
                ClientId = client2.Id
            };

            service.Update(dto);

            var unchanged = context.Subscriptions.Find(sub.Id);
            Assert.Equal(SubscriptionFrequency.Weekly, unchanged.Frequency);
            Assert.Equal(2, unchanged.MaxDogsAllowed);
            Assert.False(unchanged.IsActive);
        }

        [Fact]
        public void Delete_ShouldMarkSubscriptionAsDeleted()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Frodo", PhoneNumber = "606", Address = "Shire" };
            var sub = new Subscription { Client = client, IsDeleted = false };
            context.AddRange(client, sub);
            context.SaveChanges();

            var service = new SubscriptionService(context);
            service.Delete(sub.Id);

            var result = context.Subscriptions.Find(sub.Id);
            Assert.True(result.IsDeleted);
        }

    }
}
