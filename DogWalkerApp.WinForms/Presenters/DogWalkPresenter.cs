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

        public DogWalkPresenter(
            IDogWalkView view,
            IDogWalkService service,
            IDogService dogService,
            IWalkerService walkerService)
        {
            _view = view;
            _service = service;
            _dogService = dogService;
            _walkerService = walkerService;

            _view.CreateClicked += OnCreate;
            _view.UpdateClicked += OnUpdate;
            _view.DeleteClicked += OnDelete;
            _view.SearchClicked += OnSearch;
            _view.WalkSelected += OnSelected;

            LoadDogs();
            LoadWalkers();
            LoadWalks();
        }

        private void LoadDogs()
        {
            var dogs = _dogService.GetAll();
            _view.LoadDogs(dogs);
        }

        private void LoadWalkers()
        {
            var walkers = _walkerService.GetAll();
            _view.LoadWalkers(walkers);
        }

        private void LoadWalks()
        {
            var walks = _service.GetAll();
            _view.LoadWalks(walks);
        }

        private void OnCreate(object? sender, EventArgs e)
        {
            var dto = new DogWalkDto
            {
                WalkDate = _view.WalkDate,
                WalkerId = _view.SelectedWalkerId,
                DogIds = _view.SelectedDogIds
            };

            try
            {
                _service.Create(dto);
                _view.ShowMessage("Dog walk created successfully.");
                LoadWalks();
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

            var dto = new DogWalkDto
            {
                Id = _view.SelectedWalkId,
                WalkDate = _view.WalkDate,
                WalkerId = _view.SelectedWalkerId,
                DogIds = _view.SelectedDogIds
            };

            try
            {
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

            _view.LoadWalks(results);
        }

        private void OnSelected(object? sender, EventArgs e)
        {
            var walk = _service.GetById(_view.SelectedWalkId);
            if (walk != null)
                _view.SetFields(walk);
        }
    }
}
