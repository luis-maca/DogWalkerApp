using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.Application.Interfaces;

public interface IDogService
{
    List<DogDto> GetAll();
    DogDto? GetById(int id);
    List<DogDto> GetByClientId(int clientId);
    void Create(DogDto dto);
    void Update(DogDto dto);
    void Delete(int id);
    List<DogDto> Search(string term);
}
