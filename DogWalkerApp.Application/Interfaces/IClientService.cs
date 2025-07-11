using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Entities;

namespace DogWalkerApp.Application.Interfaces;

public interface IClientService
{
    IEnumerable<ClientDto> GetAll();
    ClientDto GetById(int id);
    void Create(ClientDto clientDto);
    void Update(ClientDto clientDto);
    void Delete(int id);
    IEnumerable<ClientDto> Search(string term);

}
