using Xunit;
using DogWalkerApp.Infrastructure.Services;
using DogWalkerApp.Infrastructure.Data;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogWalkerApp.Tests.Services
{
    public class DogWalkServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new DogWalkerDbContext(options);
        }

        #region Create

        [Fact]
        public void Create_ShouldAddWalk_WhenValid()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Gandalf", PhoneNumber = "101", Address = "Middle-earth" };
            var dog = new Dog { Name = "Shadowfax", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 2 };
            var walker = new Walker { FullName = "Aragorn", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now.AddHours(1),
                DurationMinutes = 60,
                DogIds = new List<int> { dog.Id }
            };

            service.Create(dto);

            Assert.Single(context.DogWalks);
            Assert.Single(context.DogWalkDogs);
        }

        [Fact]
        public void Create_ShouldThrow_WhenNoDogsSelected()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Legolas", IsAvailable = true, PhoneNumber = "104" };
            context.Walkers.Add(walker);
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 30,
                DogIds = new List<int>() // empty
            };

            var ex = Assert.Throws<Exception>(() => service.Create(dto));
            Assert.Equal("At least one dog must be selected for the walk.", ex.Message);
        }

        [Fact]
        public void Create_ShouldThrow_WhenWalkerIsUnavailable()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Boromir", IsAvailable = false, PhoneNumber = "104" };
            var client = new Client { Name = "Faramir", PhoneNumber = "999", Address = "Gondor" };
            var dog = new Dog { Name = "Huan", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 1 };

            context.AddRange(walker, client, dog, sub);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 30,
                DogIds = new List<int> { dog.Id }
            };

            var ex = Assert.Throws<Exception>(() => service.Create(dto));
            Assert.Equal("Walker is not available.", ex.Message);
        }

        [Fact]
        public void Create_ShouldThrow_WhenExceedsMaxDogsPerWalk()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Eomer", IsAvailable = true, PhoneNumber = "104" };
            var client = new Client { Name = "Theoden", PhoneNumber = "111", Address = "Rohan" };
            var dogs = new List<Dog>
            {
                new Dog { Name = "A", Client = client },
                new Dog { Name = "B", Client = client },
                new Dog { Name = "C", Client = client },
                new Dog { Name = "D", Client = client }
            };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 10 };

            context.AddRange(walker, client);
            context.Dogs.AddRange(dogs);
            context.Subscriptions.Add(sub);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now.AddHours(1),
                DurationMinutes = 30,
                DogIds = dogs.Select(d => d.Id).ToList()
            };

            var ex = Assert.Throws<Exception>(() => service.Create(dto));
            Assert.Equal("Cannot assign more than 3 dogs for the same walk.", ex.Message);
        }

        [Fact]
        public void Create_ShouldThrow_WhenClientHasNoSubscription()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Radagast", IsAvailable = true, PhoneNumber = "104" };
            var client = new Client { Name = "Treebeard", PhoneNumber = "303", Address = "Fangorn" };
            var dog = new Dog { Name = "Entling", Client = client };

            context.AddRange(walker, client, dog);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now.AddHours(1),
                DurationMinutes = 30,
                DogIds = new List<int> { dog.Id }
            };

            var ex = Assert.Throws<Exception>(() => service.Create(dto));
            Assert.Equal("Client 'Treebeard' must have an active subscription.", ex.Message);
        }

        #endregion

        #region Search / Retrieval

        [Fact]
        public void GetAll_ShouldReturnAllWalks()
        {
            var context = GetInMemoryDbContext();
            var walker = new Walker { FullName = "Gimli", IsAvailable = true, PhoneNumber = "104" };
            var client = new Client { Name = "Dain", PhoneNumber = "555", Address = "Iron Hills" };
            var dog = new Dog { Name = "Durin", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 2 };

            context.AddRange(walker, client, dog, sub);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3" , Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            service.Create(new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 45,
                DogIds = new List<int> { dog.Id }
            });

            var result = service.GetAll();
            Assert.Single(result);
            Assert.Equal("Gimli", result.First().WalkerName);
        }

        [Fact]
        public void GetById_ShouldReturnWalk()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Balin", PhoneNumber = "101", Address = "Moria" };
            var dog = new Dog { Name = "Gimli", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 2 };
            var walker = new Walker { FullName = "Thorin", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 45,
                DogIds = new List<int> { dog.Id }
            };

            service.Create(dto);
            var walk = context.DogWalks.First();

            var result = service.GetById(walk.Id);

            Assert.NotNull(result);
            Assert.Equal("Thorin", result.WalkerName);
            Assert.Contains("Gimli", result.DogNames);
        }

        [Fact]
        public void Search_ShouldReturnWalksMatchingDogName()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Dwalin", PhoneNumber = "200", Address = "Erebor" };
            var dog = new Dog { Name = "Durin", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 1 };
            var walker = new Walker { FullName = "Fili", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            service.Create(new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 60,
                DogIds = new List<int> { dog.Id }
            });

            var result = service.Search("durin").ToList();

            Assert.Single(result);
            Assert.Contains("Durin", result.First().DogNames);
        }

        [Fact]
        public void Search_ShouldReturnWalksMatchingClientName()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Dain", PhoneNumber = "201", Address = "Iron Hills" };
            var dog = new Dog { Name = "Oin", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 1 };
            var walker = new Walker { FullName = "Gloin", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            service.Create(new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 30,
                DogIds = new List<int> { dog.Id }
            });

            var result = service.Search("dain").ToList();

            Assert.Single(result);
            Assert.Contains("Dain", result.First().ClientNames);
        }

        [Fact]
        public void Search_ShouldReturnEmpty_WhenNoMatch()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Bombur", PhoneNumber = "404", Address = "Blue Mountains" };
            var dog = new Dog { Name = "Bofur", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 1 };
            var walker = new Walker { FullName = "Bifur", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            service.Create(new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 60,
                DogIds = new List<int> { dog.Id }
            });

            var result = service.Search("sauron").ToList();

            Assert.Empty(result);
        }
        #endregion

        [Fact]
        public void Update_ShouldRemoveAndRecreateWalk()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Beorn", PhoneNumber = "700", Address = "Forest Edge" };
            var dog1 = new Dog { Name = "Bear", Client = client };
            var dog2 = new Dog { Name = "Warg", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 2 };
            var walker = new Walker { FullName = "Thranduil", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog1, dog2, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 30,
                DogIds = new List<int> { dog1.Id }
            };

            service.Create(dto);
            var existingWalkId = context.DogWalks.First().Id;

            dto.Id = existingWalkId;
            dto.DogIds = new List<int> { dog2.Id };

            service.Update(dto);

            var updated = context.DogWalks
                          .Include(w => w.Dogs)
                          .OrderByDescending(w => w.Id)
                          .FirstOrDefault();

            Assert.NotNull(updated);
            Assert.Single(updated.Dogs);
            Assert.Equal(dog2.Id, updated.Dogs.First().DogId);
        }

        [Fact]
        public void Delete_ShouldRemoveWalkAndDogs()
        {
            var context = GetInMemoryDbContext();

            var client = new Client { Name = "Eowyn", PhoneNumber = "303", Address = "Edoras" };
            var dog = new Dog { Name = "Snowmane", Client = client };
            var sub = new Subscription { Client = client, IsActive = true, MaxDogsAllowed = 1 };
            var walker = new Walker { FullName = "Eomer", IsAvailable = true, PhoneNumber = "104" };

            context.AddRange(client, dog, sub, walker);
            context.AppConfigurations.Add(new AppConfiguration { Key = "MaxDogsPerWalk", Value = "3", Description = "Max Dogs Per Walk" });
            context.SaveChanges();

            var service = new DogWalkService(context);
            var dto = new DogWalkDto
            {
                WalkerId = walker.Id,
                WalkDate = DateTime.Now,
                DurationMinutes = 60,
                DogIds = new List<int> { dog.Id }
            };

            service.Create(dto);
            var walk = context.DogWalks.First();

            service.Delete(walk.Id);

            Assert.Empty(context.DogWalks);
            Assert.Empty(context.DogWalkDogs);
        }

    }

}
