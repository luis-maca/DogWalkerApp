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
    public class ClientServiceTests
    {
        private DogWalkerDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new DogWalkerDbContext(options);
        }

        [Fact]
        public void Create_ShouldAddClientToDatabase()
        {
            var context = GetInMemoryDbContext();
            var service = new ClientService(context);

            var clientDto = new ClientDto
            {
                Name = "John Doe",
                PhoneNumber = "12345678",
                Address = "Mordor"
            };

            service.Create(clientDto);

            var created = context.Clients.FirstOrDefault();
            Assert.NotNull(created);
            Assert.Equal("John Doe", created.Name);
        }

        [Fact]
        public void GetAll_ShouldReturnOnlyNonDeletedClients()
        {
            var context = GetInMemoryDbContext();
            context.Clients.AddRange(
                new Client { Name = "Active", PhoneNumber = "1111", Address = "The Shire", IsDeleted = false },
                new Client { Name = "Deleted", PhoneNumber = "2222", Address = "Mordor", IsDeleted = true }
            );
            context.SaveChanges();

            var service = new ClientService(context);
            var clients = service.GetAll().ToList();

            Assert.Single(clients);
            Assert.Equal("Active", clients[0].Name);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenClientIsDeleted()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Ghost", PhoneNumber = "0000", Address = "Narnia", IsDeleted = true };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new ClientService(context);
            var result = service.GetById(client.Id);

            Assert.Null(result);
        }

        [Fact]
        public void GetById_ShouldReturnClient_WhenClientIsActive()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Active", PhoneNumber = "1234", Address = "Hogwarts", IsDeleted = false };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new ClientService(context);
            var result = service.GetById(client.Id);

            Assert.NotNull(result);
            Assert.Equal("Active", result.Name);
        }

        [Fact]
        public void Delete_ShouldSetIsDeletedToTrue()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "To Delete", PhoneNumber = "9999", Address = "Avalon" };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new ClientService(context);
            service.Delete(client.Id);

            var updated = context.Clients.Find(client.Id);
            Assert.True(updated.IsDeleted);
        }

        [Fact]
        public void Delete_ShouldDoNothing_WhenClientDoesNotExist()
        {
            var context = GetInMemoryDbContext();
            var service = new ClientService(context);

            service.Delete(999); // Non-existent ID

            Assert.Empty(context.Clients);
        }

        [Fact]
        public void Update_ShouldModifyClientFields()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Old", PhoneNumber = "1111", Address = "Oz" };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new ClientService(context);
            var dto = new ClientDto
            {
                Id = client.Id,
                Name = "New",
                PhoneNumber = "2222",
                Address = "Middle-earth"
            };

            service.Update(dto);

            var updated = context.Clients.Find(client.Id);
            Assert.Equal("New", updated.Name);
            Assert.Equal("2222", updated.PhoneNumber);
            Assert.Equal("Middle-earth", updated.Address);
        }

        [Fact]
        public void Update_ShouldDoNothing_WhenClientIsDeleted()
        {
            var context = GetInMemoryDbContext();
            var client = new Client { Name = "Original", PhoneNumber = "0000", Address = "Atlantis", IsDeleted = true };
            context.Clients.Add(client);
            context.SaveChanges();

            var service = new ClientService(context);
            var dto = new ClientDto
            {
                Id = client.Id,
                Name = "Changed",
                PhoneNumber = "1234",
                Address = "Camelot"
            };

            service.Update(dto);

            var updated = context.Clients.Find(client.Id);
            Assert.Equal("Original", updated.Name);
        }

        [Fact]
        public void Search_ShouldReturnMatchingClients()
        {
            var context = GetInMemoryDbContext();
            context.Clients.AddRange(
                new Client { Name = "Alice", PhoneNumber = "5555", Address = "Neverland", IsDeleted = false },
                new Client { Name = "Bob", PhoneNumber = "1234", Address = "Westeros", IsDeleted = false },
                new Client { Name = "Deleted", PhoneNumber = "0000", Address = "Underworld", IsDeleted = true }
            );
            context.SaveChanges();

            var service = new ClientService(context);
            var results = service.Search("Bob");

            Assert.Single(results);
            Assert.Equal("Bob", results.First().Name);
        }

        [Fact]
        public void Search_ShouldReturnEmpty_WhenNoMatch()
        {
            var context = GetInMemoryDbContext();
            context.Clients.Add(new Client { Name = "Alice", PhoneNumber = "5555", Address = "Neverland", IsDeleted = false });
            context.SaveChanges();

            var service = new ClientService(context);
            var result = service.Search("xyz");

            Assert.Empty(result);
        }
    }
}
