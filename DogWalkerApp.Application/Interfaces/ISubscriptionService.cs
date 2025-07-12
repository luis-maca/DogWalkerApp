using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.Application.Interfaces;

public interface ISubscriptionService
{
    IEnumerable<SubscriptionDto> GetAll();
    SubscriptionDto GetById(int id);
    void Create(SubscriptionDto dto);
    void Update(SubscriptionDto dto);
    void Delete(int id);
}
