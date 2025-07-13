using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.Application.Interfaces
{
    public interface IDogWalkService
    {
        IEnumerable<DogWalkDto> GetAll();
        DogWalkDto? GetById(int id);
        IEnumerable<DogWalkDto> GetByDateRange(DateTime start, DateTime end);
        void Create(DogWalkDto dto);
        void Update(DogWalkDto dto);
        void Delete(int id);
        IEnumerable<DogWalkDto> Search(string term);

    }
}
