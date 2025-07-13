using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters
{
    public class DogWalkPresenter
    {
        private readonly IDogWalkView _view;
        private readonly IDogWalkService _service;
        private readonly IDogService _dogService;
        private readonly IWalkerService _walkerService;
        private readonly IClientService _clientService;

        public DogWalkPresenter(
            IDogWalkView view,
            IDogWalkService service,
            IDogService dogService,
            IWalkerService walkerService,
            IClientService clientService)
        {
            _view = view;
            _service = service;
            _dogService = dogService;
            _walkerService = walkerService;
            _clientService = clientService;

            _view.CreateClicked += OnCreate;
            _view.UpdateClicked += OnUpdate;
            _view.DeleteClicked += OnDelete;
            _view.SearchClicked += OnSearch;
            _view.WalkSelected += OnSelected;
            _view.ClientChanged += OnClientChanged;

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            var walkers = _walkerService.GetAllActive();
            _view.LoadWalkers(walkers);

            var clients = _clientService.GetAll()
                .Where(c => c.HasActiveSubscription && c.DogCount > 0)
                .ToList();
            _view.LoadClients(clients);

            LoadWalks();
        }


        private void LoadWalks()
        {
            var walks = _service.GetAll();
            _view.LoadDogWalks(walks);
        }

        private void LoadDogsForClient(int clientId)
        {
            var dogs = _dogService.GetByClientId(clientId);
            _view.LoadAvailableDogs(dogs);
        }

        private void OnCreate(object? sender, EventArgs e)
        {
            try
            {
                var dto = new DogWalkDto
                {
                    WalkDate = _view.WalkDate,
                    WalkerId = _view.SelectedWalkerId,
                    DogIds = _view.SelectedDogIds,
                    DurationMinutes = _view.DurationMinutes
                };

                _service.Create(dto);
                _view.ShowMessage("Dog walk created successfully.");
                LoadInitialData();
                _view.ClearForm();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error: {ex.Message}");
            }
        }

        private void OnUpdate(object? sender, EventArgs e)
        {
            if (_view.SelectedWalkId == -1)
            {
                _view.ShowMessage("Please select a walk to update.");
                return;
            }

            try
            {
                var dto = new DogWalkDto
                {
                    Id = _view.SelectedWalkId,
                    WalkDate = _view.WalkDate,
                    WalkerId = _view.SelectedWalkerId,
                    DogIds = _view.SelectedDogIds,
                    DurationMinutes = _view.DurationMinutes
                };

                _service.Update(dto);
                _view.ShowMessage("Dog walk updated successfully.");
                LoadWalks();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error: {ex.Message}");
            }
        }

        private void OnDelete(object? sender, EventArgs e)
        {
            if (_view.SelectedWalkId == -1)
            {
                _view.ShowMessage("Please select a walk to delete.");
                return;
            }

            _service.Delete(_view.SelectedWalkId);
            _view.ShowMessage("Dog walk deleted.");
            LoadWalks();
        }

        private void OnSearch(object? sender, EventArgs e)
        {
            var results = _view.SearchAllChecked
                ? _service.GetAll()
                : _service.Search(_view.SearchTerm);

            _view.LoadDogWalks(results);
        }

        private void OnSelected(object? sender, EventArgs e)
        {
            var walk = _service.GetById(_view.SelectedWalkId);
            if (walk != null)
                _view.SetFields(walk);
        }

        private void OnClientChanged(object? sender, EventArgs e)
        {
            var clientId = _view.SelectedClientId;
            LoadDogsForClient(clientId);
        }

    }
}
