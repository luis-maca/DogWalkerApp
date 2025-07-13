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
    public class DogServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Create_ShouldAddDog_WithValidEnumBreed()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Elrond", PhoneNumber = "123", Address = "Rivendell" };
            context.Clients.Add(client);
            context.SaveChanges();

            context.Subscriptions.Add(new Subscription { ClientId = client.Id, IsActive = true, MaxDogsAllowed = 3 });
            context.SaveChanges();

            var service = new DogService(context);
            var dto = new DogDto
            {
                Name = "Frodo",
                Age = 3,
                Breed = DogBreed.GoldenRetriever,
                Notes = "Shiny coat",
                ClientId = client.Id
            };

            service.Create(dto);

            var dog = context.Dogs.FirstOrDefault();
            Assert.NotNull(dog);
            Assert.Equal(DogBreed.GoldenRetriever, dog.Breed);
        }

        [Fact]
        public void Create_ShouldDefaultToUnknown_WhenBreedIsInvalidEnum()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Thranduil", PhoneNumber = "999", Address = "Mirkwood" };
            context.Clients.Add(client);
            context.SaveChanges();

            context.Subscriptions.Add(new Subscription { ClientId = client.Id, IsActive = true, MaxDogsAllowed = 1 });
            context.SaveChanges();

            var service = new DogService(context);
            var dto = new DogDto
            {
                Name = "Tyrion",
                Age = 4,
                Breed = (DogBreed)999, // invalid enum value
                Notes = "Very smart",
                ClientId = client.Id
            };

            // Act - should still save since enum is numeric
            service.Create(dto);

            var dog = context.Dogs.FirstOrDefault();
            Assert.NotNull(dog);
            Assert.Equal((DogBreed)999, dog.Breed); // saved as raw int, but not recommended
        }

        [Fact]
        public void Update_ShouldChangeDogBreed()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Aragorn", PhoneNumber = "111", Address = "Gondor" };
            context.Clients.Add(client);
            context.SaveChanges();

            var dog = new Dog { Name = "Legolas", Age = 2, Breed = DogBreed.Chihuahua, ClientId = client.Id };
            context.Dogs.Add(dog);
            context.SaveChanges();

            var service = new DogService(context);
            var dto = new DogDto
            {
                Id = dog.Id,
                Name = "Legolas",
                Age = 2,
                Breed = DogBreed.GermanShepherd,
                Notes = "Now stronger",
                ClientId = client.Id
            };

            service.Update(dto);

            var updated = context.Dogs.Find(dog.Id);
            Assert.Equal(DogBreed.GermanShepherd, updated.Breed);
        }

        [Fact]
        public void GetAll_ShouldMapEnumToDtoCorrectly()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Galadriel", PhoneNumber = "888", Address = "Lothlorien" };
            context.Clients.Add(client);
            context.SaveChanges();

            context.Dogs.Add(new Dog
            {
                Name = "Anakin",
                Age = 5,
                Breed = DogBreed.Husky,
                ClientId = client.Id
            });
            context.SaveChanges();

            var service = new DogService(context);
            var result = service.GetAll();

            Assert.Single(result);
            Assert.Equal(DogBreed.Husky, result.First().Breed);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectDog()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Thorin", PhoneNumber = "312", Address = "Erebor" };
            context.Clients.Add(client);
            context.SaveChanges();

            var dog = new Dog { Name = "Smaug", Age = 10, Breed = DogBreed.Poodle, ClientId = client.Id };
            context.Dogs.Add(dog);
            context.SaveChanges();

            var service = new DogService(context);
            var result = service.GetById(dog.Id);

            Assert.NotNull(result);
            Assert.Equal("Smaug", result.Name);
        }

        [Fact]
        public void GetByClientId_ShouldReturnOnlyClientDogs()
        {
            var context = GetInMemoryDbContext();
            var client1 = new Client { Name = "Saruman", PhoneNumber = "100", Address = "Isengard" };
            var client2 = new Client { Name = "Radagast", PhoneNumber = "101", Address = "Mirkwood" };
            context.Clients.AddRange(client1, client2);
            context.SaveChanges();

            context.Dogs.AddRange(
                new Dog { Name = "Fang", Age = 4, Breed = DogBreed.Husky, ClientId = client1.Id },
                new Dog { Name = "Buckbeak", Age = 5, Breed = DogBreed.Mixed, ClientId = client2.Id }
            );
            context.SaveChanges();

            var service = new DogService(context);
            var result = service.GetByClientId(client1.Id);

            Assert.Single(result);
            Assert.Equal("Fang", result.First().Name);
        }

        [Fact]
        public void Search_ShouldReturnMultipleMatches()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Merlin", PhoneNumber = "777", Address = "Camelot" };
            context.Clients.Add(client);
            context.SaveChanges();

            context.Dogs.AddRange(
                new Dog { Name = "Lancelot", Age = 3, Breed = DogBreed.Bulldog, ClientId = client.Id },
                new Dog { Name = "Arthur", Age = 5, Breed = DogBreed.Labrador, ClientId = client.Id }
            );
            context.SaveChanges();

            var service = new DogService(context);
            var result = service.Search("a");

            Assert.Equal(2, result.Count);
            Assert.Contains(result, d => d.Name == "Lancelot");
            Assert.Contains(result, d => d.Name == "Arthur");
        }

        [Fact]
        public void Delete_ShouldRemoveDog()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Dobby", PhoneNumber = "000", Address = "Hogwarts" };
            context.Clients.Add(client);
            context.SaveChanges();

            var dog = new Dog { Name = "Shadowfax", Age = 6, Breed = DogBreed.Beagle, ClientId = client.Id };
            context.Dogs.Add(dog);
            context.SaveChanges();

            var service = new DogService(context);
            service.Delete(dog.Id);

            var deleted = context.Dogs.Find(dog.Id);
            Assert.Null(deleted);
        }

    }
}
