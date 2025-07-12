using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.Application.Interfaces;

public interface IPaymentService
{
    IEnumerable<PaymentDto> GetAll();
    PaymentDto? GetById(int id);
    void Create(PaymentDto dto);
    void Update(PaymentDto dto);
    void Delete(int id);
    IEnumerable<PaymentDto> Search(string clientName);
}
