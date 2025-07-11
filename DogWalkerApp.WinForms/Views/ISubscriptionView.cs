using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.WinForms.Views;

public interface ISubscriptionView
{
    int SelectedSubscriptionId { get; }

    int SelectedClientId { get; }
    SubscriptionFrequency SelectedFrequency { get; }
    int MaxDogsAllowed { get; }
    bool IsActive { get; }

    string SearchTerm { get; }
    bool SearchAllChecked { get; }
    bool IsClientLocked { get; }

    void LoadSubscriptions(IEnumerable<SubscriptionDto> items);
    void LoadClients(IEnumerable<ClientDto> clients);
    void SetFields(SubscriptionDto dto);
    void ClearForm();
    void ShowMessage(string message);

    event EventHandler CreateClicked;
    event EventHandler UpdateClicked;
    event EventHandler DeleteClicked;
    event EventHandler SearchClicked;
    event EventHandler SubscriptionSelected;
}
