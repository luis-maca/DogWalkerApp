using Xunit;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DogWalkerApp.Tests.Services
{
    public class WalkerServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Create_ShouldAddWalker()
        {
            var context = GetInMemoryDbContext();
            var service = new WalkerService(context);

            var dto = new WalkerDto
            {
                FullName = "Aragorn",
                PhoneNumber = "123456789",
                IsAvailable = true
            };

            service.Create(dto);

            var walker = context.Walkers.FirstOrDefault();
            Assert.NotNull(walker);
            Assert.Equal("Aragorn", walker.FullName);
        }

        [Fact]
        public void GetAll_ShouldReturnOnlyNonDeletedWalkers()
        {
            var context = GetInMemoryDbContext();
            context.Walkers.AddRange(
                new Walker { FullName = "Boromir", PhoneNumber = "1111", IsAvailable = true, IsDeleted = false },
                new Walker { FullName = "Denethor", PhoneNumber = "2222", IsAvailable = false, IsDeleted = true }
            );
            context.SaveChanges();

            var service = new WalkerService(context);
            var result = service.GetAll();

            Assert.Single(result);
            Assert.Equal("Boromir", result.First().FullName);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenWalkerIsDeleted()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Gollum", PhoneNumber = "0000", IsAvailable = false, IsDeleted = true };
            context.Walkers.Add(walker);
            context.SaveChanges();

            var service = new WalkerService(context);
            var result = service.GetById(walker.Id);

            Assert.Null(result);
        }

        [Fact]
        public void GetById_ShouldReturnWalker_WhenNotDeleted()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Legolas", PhoneNumber = "9999", IsAvailable = true, IsDeleted = false };
            context.Walkers.Add(walker);
            context.SaveChanges();

            var service = new WalkerService(context);
            var result = service.GetById(walker.Id);

            Assert.NotNull(result);
            Assert.Equal("Legolas", result.FullName);
        }

        [Fact]
        public void Update_ShouldModifyWalkerFields()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Faramir", PhoneNumber = "7777", IsAvailable = true };
            context.Walkers.Add(walker);
            context.SaveChanges();

            var service = new WalkerService(context);
            var dto = new WalkerDto
            {
                Id = walker.Id,
                FullName = "Faramir II",
                PhoneNumber = "8888",
                IsAvailable = false
            };

            service.Update(dto);

            var updated = context.Walkers.Find(walker.Id);
            Assert.Equal("Faramir II", updated.FullName);
            Assert.Equal("8888", updated.PhoneNumber);
            Assert.False(updated.IsAvailable);
        }

        [Fact]
        public void Delete_ShouldMarkWalkerAsDeleted()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Thranduil", PhoneNumber = "3333", IsAvailable = true };
            context.Walkers.Add(walker);
            context.SaveChanges();

            var service = new WalkerService(context);
            service.Delete(walker.Id);

            var deleted = context.Walkers.Find(walker.Id);
            Assert.True(deleted.IsDeleted);
        }

        [Fact]
        public void Search_ShouldReturnMatchingWalkers()
        {
            var context = GetInMemoryDbContext();
            context.Walkers.AddRange(
                new Walker { FullName = "Eowyn", PhoneNumber = "4444", IsAvailable = true },
                new Walker { FullName = "Eomer", PhoneNumber = "5555", IsAvailable = true }
            );
            context.SaveChanges();

            var service = new WalkerService(context);
            var result = service.Search("wyn");

            Assert.Single(result);
            Assert.Equal("Eowyn", result.First().FullName);
        }

        [Fact]
        public void Search_ShouldReturnEmpty_WhenNoMatch()
        {
            var context = GetInMemoryDbContext();
            context.Walkers.Add(new Walker { FullName = "Galadriel", PhoneNumber = "6666", IsAvailable = true });
            context.SaveChanges();

            var service = new WalkerService(context);
            var result = service.Search("saruman");

            Assert.Empty(result);
        }
    }
}
