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
    public class PaymentServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Create_ShouldAddPayment()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Eowyn", PhoneNumber = "555", Address = "Rohan" };
            context.Clients.Add(client);
            context.SaveChanges();

            var subscription = new Subscription { ClientId = client.Id, Frequency = SubscriptionFrequency.Monthly, IsActive = true };
            context.Subscriptions.Add(subscription);
            context.SaveChanges();

            var service = new PaymentService(context);
            var dto = new PaymentDto
            {
                SubscriptionId = subscription.Id,
                Date = DateTime.Today,
                Amount = 50m,
                Method = PaymentMethod.Card
            };

            service.Create(dto);

            var payment = context.Payments.FirstOrDefault();
            Assert.NotNull(payment);
            Assert.Equal(PaymentMethod.Card, payment.Method);
        }

        [Fact]
        public void GetAll_ShouldIncludeClientNameAndFrequency()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Faramir", PhoneNumber = "777", Address = "Gondor" };
            var subscription = new Subscription { Client = client, Frequency = SubscriptionFrequency.Weekly };
            var payment = new Payment
            {
                Subscription = subscription,
                Date = DateTime.Today,
                Amount = 75,
                Method = PaymentMethod.Transfer
            };
            context.AddRange(client, subscription, payment);
            context.SaveChanges();

            var service = new PaymentService(context);
            var result = service.GetAll().FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal("Faramir", result.SubscriptionClientName);
            Assert.Equal(SubscriptionFrequency.Weekly, result.Frequency);
        }

        [Fact]
        public void Update_ShouldModifyPaymentDetails()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Boromir", PhoneNumber = "888", Address = "Gondor" };
            var subscription = new Subscription { Client = client, Frequency = SubscriptionFrequency.Monthly };
            var payment = new Payment
            {
                Subscription = subscription,
                Date = DateTime.Today.AddDays(-5),
                Amount = 60,
                Method = PaymentMethod.Cash
            };
            context.AddRange(client, subscription, payment);
            context.SaveChanges();

            var service = new PaymentService(context);
            var dto = new PaymentDto
            {
                Id = payment.Id,
                SubscriptionId = subscription.Id,
                Date = DateTime.Today,
                Amount = 100,
                Method = PaymentMethod.Mobile
            };

            service.Update(dto);

            var updated = context.Payments.Find(payment.Id);
            Assert.Equal(100, updated.Amount);
            Assert.Equal(PaymentMethod.Mobile, updated.Method);
        }

        [Fact]
        public void Delete_ShouldRemovePayment()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Gimli", PhoneNumber = "999", Address = "Mines of Moria" };
            var subscription = new Subscription { Client = client, Frequency = SubscriptionFrequency.Monthly };
            var payment = new Payment
            {
                Subscription = subscription,
                Date = DateTime.Today,
                Amount = 85,
                Method = PaymentMethod.Cash
            };
            context.AddRange(client, subscription, payment);
            context.SaveChanges();

            var service = new PaymentService(context);
            service.Delete(payment.Id);

            var deleted = context.Payments.Find(payment.Id);
            Assert.Null(deleted);
        }

        [Fact]
        public void Search_ShouldReturnPaymentsMatchingClientName()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Arwen", PhoneNumber = "000", Address = "Rivendell" };
            var subscription = new Subscription { Client = client, Frequency = SubscriptionFrequency.Monthly };
            var payment = new Payment
            {
                Subscription = subscription,
                Date = DateTime.Today,
                Amount = 95,
                Method = PaymentMethod.Card
            };
            context.AddRange(client, subscription, payment);
            context.SaveChanges();

            var service = new PaymentService(context);
            var results = service.Search("arw");

            Assert.Single(results);
            Assert.Equal("Arwen", results.First().SubscriptionClientName);
        }
    }
}
