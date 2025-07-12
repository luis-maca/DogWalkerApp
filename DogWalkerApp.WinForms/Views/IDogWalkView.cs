using DogWalkerApp.Application.DTOs;

namespace DogWalkerApp.WinForms.Views
{
    public interface IDogWalkView
    {
        int SelectedWalkId { get; }

        int SelectedWalkerId { get; }
        DateTime WalkStartDate { get; }

        int SelectedClientId { get; }
        int SelectedAvailableDogId { get; }

        string SearchTerm { get; }
        bool SearchAllChecked { get; }

        List<int> SelectedDogIds { get; }

        event EventHandler CreateClicked;
        event EventHandler UpdateClicked;
        event EventHandler DeleteClicked;
        event EventHandler SearchClicked;
        event EventHandler WalkSelected;

        void LoadWalkers(IEnumerable<WalkerDto> walkers);
        void LoadClients(IEnumerable<ClientDto> clients);
        void LoadAvailableDogs(IEnumerable<DogDto> dogs);

        void LoadDogWalks(IEnumerable<DogWalkDto> walks);
        void SetFields(DogWalkDto dto);
        void ShowMessage(string message);
        void ClearForm();
    }
}
