using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters;

public class SubscriptionPresenter
{
    private readonly ISubscriptionView _view;
    private readonly ISubscriptionService _service;
    private readonly IClientService _clientService;

    public SubscriptionPresenter(ISubscriptionView view, ISubscriptionService service, IClientService clientService)
    {
        _view = view;
        _service = service;
        _clientService = clientService;

        _view.CreateClicked += OnCreate;
        _view.UpdateClicked += OnUpdate;
        _view.DeleteClicked += OnDelete;
        _view.SearchClicked += OnSearch;
        _view.SubscriptionSelected += OnSelected;


        LoadClients();

        LoadSubscriptions();
    }

    private void LoadSubscriptions()
    {
        var list = _service.GetAll();
        _view.LoadSubscriptions(list);
    }

    private void LoadClients()
    {
        var clients = _clientService.GetAll();
        _view.LoadClients(clients);
    }

    private void OnCreate(object? sender, EventArgs e)
    {
        if (!_view.IsActive)
        {
            _view.ShowMessage("New subscriptions must be active.");
            return;
        }

        var existingActive = _service
            .GetAll()
            .Any(s => s.ClientId == _view.SelectedClientId && s.IsActive);

        if (existingActive)
        {
            _view.ShowMessage("This client already has an active subscription.");
            return;
        }

        var dto = new SubscriptionDto
        {
            Frequency = _view.SelectedFrequency,
            MaxDogsAllowed = _view.MaxDogsAllowed,
            IsActive = _view.IsActive,
            ClientId = _view.SelectedClientId
        };

        _service.Create(dto);
        _view.ShowMessage("Subscription created.");
        LoadSubscriptions();
        _view.ClearForm();
    }



    private void OnUpdate(object? sender, EventArgs e)
    {
        var dto = new SubscriptionDto
        {
            Id = _view.SelectedSubscriptionId,
            Frequency = _view.SelectedFrequency,
            MaxDogsAllowed = _view.MaxDogsAllowed,
            IsActive = _view.IsActive,
            ClientId = _view.SelectedClientId
        };

        _service.Update(dto);
        _view.ShowMessage("Subscription updated.");
        LoadSubscriptions();
    }

    private void OnDelete(object? sender, EventArgs e)
    {
        _service.Delete(_view.SelectedSubscriptionId);
        _view.ShowMessage("Subscription deleted.");
        LoadSubscriptions();
    }

    private void OnSearch(object? sender, EventArgs e)
    {
        var results = _view.SearchAllChecked
            ? _service.GetAll()
            : _service.GetAll().Where(s => s.ClientName.Contains(_view.SearchTerm)).ToList();

        _view.LoadSubscriptions(results);
    }

    private void OnSelected(object? sender, EventArgs e)
    {
        var dto = _service.GetById(_view.SelectedSubscriptionId);
        if (dto != null)
            _view.SetFields(dto);
    }
}
