using Xunit;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DogWalkerApp.Tests.Data
{
    public class DbInitializerTests
    {
        private DogWalkerDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Seed_ShouldInsertInitialData_IfDatabaseIsEmpty()
        {
            var context = GetContext();

            DbInitializer.Seed(context);

            Assert.True(context.Clients.Any());
            Assert.True(context.Walkers.Any());
            Assert.True(context.Subscriptions.Any());
            Assert.True(context.Payments.Any());
            Assert.True(context.AppConfigurations.Any());
        }

        [Fact]
        public void Seed_ShouldDoNothing_IfDataAlreadyExists()
        {
            var context = GetContext();

            context.Clients.Add(new Client { Name = "Dummy", PhoneNumber = "000", Address = "Nowhere" });
            context.SaveChanges();

            DbInitializer.Seed(context);

            // No additional clients should have been added
            Assert.Single(context.Clients);
        }
    }
}
