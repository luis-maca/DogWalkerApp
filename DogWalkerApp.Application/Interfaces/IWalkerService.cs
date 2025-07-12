using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.Application.Interfaces;

public interface IWalkerService
{
    List<WalkerDto> GetAll();
    WalkerDto? GetById(int id);
    void Create(WalkerDto dto);
    void Update(WalkerDto dto);
    void Delete(int id);
    List<WalkerDto> Search(string term);
}
