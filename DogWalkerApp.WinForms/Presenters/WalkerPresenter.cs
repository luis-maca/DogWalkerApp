using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters;

public class WalkerPresenter
{
    private readonly IWalkerView _view;
    private readonly IWalkerService _service;

    public WalkerPresenter(IWalkerView view, IWalkerService service)
    {
        _view = view;
        _service = service;

        _view.CreateClicked += OnCreate;
        _view.UpdateClicked += OnUpdate;
        _view.DeleteClicked += OnDelete;
        _view.SearchClicked += OnSearch;
        _view.WalkerSelected += OnSelected;

        LoadWalkers();
    }

    private void LoadWalkers()
    {
        _view.LoadWalkers(_service.GetAll());
    }

    private void OnCreate(object? sender, EventArgs e)
    {
        var dto = new WalkerDto
        {
            FullName = _view.FullName,
            PhoneNumber = _view.PhoneNumber,
            IsAvailable = _view.IsAvailable
        };

        _service.Create(dto);
        _view.ShowMessage("Walker created.");
        LoadWalkers();
        _view.ClearForm();
    }

    private void OnUpdate(object? sender, EventArgs e)
    {
        var dto = new WalkerDto
        {
            Id = _view.SelectedWalkerId,
            FullName = _view.FullName,
            PhoneNumber = _view.PhoneNumber,
            IsAvailable = _view.IsAvailable
        };

        _service.Update(dto);
        _view.ShowMessage("Walker updated.");
        LoadWalkers();
    }

    private void OnDelete(object? sender, EventArgs e)
    {
        _service.Delete(_view.SelectedWalkerId);
        _view.ShowMessage("Walker deleted.");
        LoadWalkers();
    }

    private void OnSearch(object? sender, EventArgs e)
    {
        var results = _view.SearchAllChecked
            ? _service.GetAll()
            : _service.Search(_view.SearchTerm);

        _view.LoadWalkers(results);
    }

    private void OnSelected(object? sender, EventArgs e)
    {
        var dto = _service.GetById(_view.SelectedWalkerId);
        if (dto != null)
            _view.SetWalkerFields(dto);
    }
}
