using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.WinForms.Views
{
    public interface IDogWalkView
    {
        // Props
        int SelectedWalkId { get; }
        int SelectedWalkerId { get; }
        int SelectedAvailableDogId { get; }
        List<int> SelectedDogIds { get; }
        DateTime WalkDate { get; }

        int DurationMinutes { get; }

        string SearchTerm { get; }
        bool SearchAllChecked { get; }
        int SelectedClientId { get; }

        // Events
        event EventHandler CreateClicked;
        event EventHandler UpdateClicked;
        event EventHandler DeleteClicked;
        event EventHandler SearchClicked;
        event EventHandler WalkSelected;
        event EventHandler ClientChanged;

        // Methods
        void LoadDogWalks(IEnumerable<DogWalkDto> walks);
        void LoadWalkers(IEnumerable<WalkerDto> walkers);
        void LoadClients(IEnumerable<ClientDto> clients);
        void LoadAvailableDogs(IEnumerable<DogDto> dogs);
        void SetFields(DogWalkDto walk);
        void ClearForm();
        void ShowMessage(string message);
    }
}
