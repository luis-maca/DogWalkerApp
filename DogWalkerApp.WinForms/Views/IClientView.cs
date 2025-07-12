using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Entities;

namespace DogWalkerApp.WinForms.Views;

public interface IClientView
{   
    string ClientName { get; }
    string PhoneNumber { get; }
    string Address { get; }

    int SelectedClientId { get; }
    string SearchTerm { get; }
    bool SearchAllChecked { get; }

    void LoadClients(IEnumerable<ClientDto> clients);
    void ClearForm();
    void ShowMessage(string message);
    void SetClientFields(ClientDto dto);

    event EventHandler CreateClicked;
    event EventHandler UpdateClicked;
    event EventHandler DeleteClicked;
    event EventHandler ClientSelected;
    event EventHandler SearchClicked;

}
