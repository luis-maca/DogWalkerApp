using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.WinForms.Views;

public interface IDogView
{
    int SelectedDogId { get; }
    int SelectedClientId { get; }
    string DogName { get; }
    int DogAge { get; }
    string DogNotes { get; }
    DogBreed SelectedBreed { get; }

    string SearchTerm { get; }
    bool SearchAllChecked { get; }

    event EventHandler CreateClicked;
    event EventHandler UpdateClicked;
    event EventHandler DeleteClicked;
    event EventHandler SearchClicked;
    event EventHandler DogSelected;

    void LoadDogs(IEnumerable<DogDto> dogs);
    void LoadClients(IEnumerable<ClientDto> clients);
    void ClearForm();
    void SetFields(DogDto dto);
    void ShowMessage(string message);
}
