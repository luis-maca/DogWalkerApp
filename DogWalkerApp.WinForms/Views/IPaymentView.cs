using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.WinForms.Views;

public interface IPaymentView
{
    int SelectedPaymentId { get; }
    int SelectedSubscriptionId { get; }
    DateTime PaymentDate { get; }
    decimal Amount { get; }
    PaymentMethod SelectedMethod { get; }

    string SearchTerm { get; }
    bool SearchAllChecked { get; }

    event EventHandler CreateClicked;
    event EventHandler UpdateClicked;
    event EventHandler DeleteClicked;
    event EventHandler SearchClicked;
    event EventHandler PaymentSelected;

    void LoadPayments(IEnumerable<PaymentDto> payments);
    void LoadSubscriptions(IEnumerable<SubscriptionDto> subscriptions);
    void SetFields(PaymentDto dto);
    void ClearForm();
    void ShowMessage(string message);
}
