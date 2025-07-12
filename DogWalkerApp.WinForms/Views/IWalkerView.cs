using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.WinForms.Views;

public interface IWalkerView
{
    int SelectedWalkerId { get; }
    string FullName { get; }
    string PhoneNumber { get; }
    bool IsAvailable { get; }

    string SearchTerm { get; }
    bool SearchAllChecked { get; }

    void LoadWalkers(IEnumerable<WalkerDto> items);
    void SetWalkerFields(WalkerDto dto);
    void ClearForm();
    void ShowMessage(string message);

    event EventHandler CreateClicked;
    event EventHandler UpdateClicked;
    event EventHandler DeleteClicked;
    event EventHandler SearchClicked;
    event EventHandler WalkerSelected;
}
