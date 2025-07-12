using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters;

public class DogPresenter
{
    private readonly IDogView _view;
    private readonly IDogService _service;
    private readonly IClientService _clientService;

    public DogPresenter(IDogView view, IDogService service, IClientService clientService)
    {
        _view = view;
        _service = service;
        _clientService = clientService;

        _view.CreateClicked += OnCreate;
        _view.UpdateClicked += OnUpdate;
        _view.DeleteClicked += OnDelete;
        _view.SearchClicked += OnSearch;
        _view.DogSelected += OnSelected;

        LoadDogs();
        LoadClients();
    }

    private void LoadDogs()
    {
        var list = _service.GetAll();
        _view.LoadDogs(list);
    }

    private void LoadClients()
    {
        var clients = _clientService.GetAll()
            .Where(c => c.HasActiveSubscription)
            .ToList();

        _view.LoadClients(clients);
    }

    private void OnCreate(object? sender, EventArgs e)
    {
        var dto = new DogDto
        {
            Name = _view.DogName,
            Age = _view.DogAge,
            Notes = _view.DogNotes,
            Breed = _view.SelectedBreed,
            ClientId = _view.SelectedClientId
        };

        try
        {
            _service.Create(dto);
            _view.ShowMessage("Dog created successfully.");
            LoadDogs();
            _view.ClearForm();
        }
        catch (Exception ex)
        {
            _view.ShowMessage($"Error: {ex.Message}");
        }
    }

    private void OnUpdate(object? sender, EventArgs e)
    {
        var dto = new DogDto
        {
            Id = _view.SelectedDogId,
            Name = _view.DogName,
            Age = _view.DogAge,
            Notes = _view.DogNotes,
            Breed = _view.SelectedBreed,
            ClientId = _view.SelectedClientId
        };

        _service.Update(dto);
        _view.ShowMessage("Dog updated.");
        LoadDogs();
    }

    private void OnDelete(object? sender, EventArgs e)
    {
        _service.Delete(_view.SelectedDogId);
        _view.ShowMessage("Dog deleted.");
        LoadDogs();
    }

    private void OnSearch(object? sender, EventArgs e)
    {
        var results = _view.SearchAllChecked
            ? _service.GetAll()
            : _service.Search(_view.SearchTerm);

        _view.LoadDogs(results);
    }

    private void OnSelected(object? sender, EventArgs e)
    {
        var dto = _service.GetById(_view.SelectedDogId);
        if (dto != null)
            _view.SetFields(dto);
    }
}
