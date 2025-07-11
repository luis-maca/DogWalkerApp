using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters;

public class ClientPresenter
{
    private readonly IClientView _view;
    private readonly IClientService _service;

    public ClientPresenter(IClientView view, IClientService service)
    {
        _view = view;
        _service = service;

        _view.CreateClicked += OnCreate;
        _view.UpdateClicked += OnUpdate;
        _view.DeleteClicked += OnDelete;
        _view.ClientSelected += OnSelected;
        _view.SearchClicked += OnSearch;

        LoadClients();
    }

    private void LoadClients()
    {
        var clients = _service.GetAll();
        _view.LoadClients(clients);
    }

    private void OnCreate(object? sender, EventArgs e)
    {
        var dto = new ClientDto
        {
            Name = _view.ClientName,
            PhoneNumber = _view.PhoneNumber,
            Address = _view.Address
        };

        _service.Create(dto);
        _view.ShowMessage("Client created successfully.");
        LoadClients();
        _view.ClearForm();
    }

    private void OnUpdate(object? sender, EventArgs e)
    {
        var client = _service.GetById(_view.SelectedClientId);
        if (client == null) return;

        client.Name = _view.ClientName;
        client.PhoneNumber = _view.PhoneNumber;
        client.Address = _view.Address;

        _service.Update(client);
        _view.ShowMessage("Client updated.");
        LoadClients();
    }

    private void OnDelete(object? sender, EventArgs e)
    {
        _service.Delete(_view.SelectedClientId);
        _view.ShowMessage("Client deleted.");
        LoadClients();
    }

    private void OnSelected(object? sender, EventArgs e)
    {
        if (_view.SelectedClientId == -1)
            return;

        var dto = _service.GetById(_view.SelectedClientId);
        if (dto != null)
            _view.SetClientFields(dto);
    }


    private void OnSearch(object? sender, EventArgs e)
    {
        var results = _view.SearchAllChecked
            ? _service.GetAll()
            : _service.Search(_view.SearchTerm);

        _view.LoadClients(results);
    }

}
