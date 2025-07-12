using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.WinForms.Views;

namespace DogWalkerApp.WinForms.Presenters;

public class PaymentPresenter
{
    private readonly IPaymentView _view;
    private readonly IPaymentService _service;
    private readonly ISubscriptionService _subscriptionService;

    public PaymentPresenter(IPaymentView view, IPaymentService service, ISubscriptionService subscriptionService)
    {
        _view = view;
        _service = service;
        _subscriptionService = subscriptionService;

        _view.CreateClicked += OnCreate;
        _view.UpdateClicked += OnUpdate;
        _view.DeleteClicked += OnDelete;
        _view.SearchClicked += OnSearch;
        _view.PaymentSelected += OnSelected;

        LoadPayments();
        LoadSubscriptions();
    }

    private void LoadPayments()
    {
        var list = _service.GetAll();
        _view.LoadPayments(list);
    }

    private void LoadSubscriptions()
    {
        var subs = _subscriptionService.GetAll();
        _view.LoadSubscriptions(subs);
    }

    private void OnCreate(object? sender, EventArgs e)
    {
        var dto = new PaymentDto
        {
            SubscriptionId = _view.SelectedSubscriptionId,
            Date = _view.PaymentDate,
            Amount = _view.Amount,
            Method = _view.SelectedMethod
        };

        _service.Create(dto);
        _view.ShowMessage("Payment created.");
        LoadPayments();
        _view.ClearForm();
    }

    private void OnUpdate(object? sender, EventArgs e)
    {
        var dto = new PaymentDto
        {
            Id = _view.SelectedPaymentId,
            SubscriptionId = _view.SelectedSubscriptionId,
            Date = _view.PaymentDate,
            Amount = _view.Amount,
            Method = _view.SelectedMethod
        };

        _service.Update(dto);
        _view.ShowMessage("Payment updated.");
        LoadPayments();
    }

    private void OnDelete(object? sender, EventArgs e)
    {
        _service.Delete(_view.SelectedPaymentId);
        _view.ShowMessage("Payment deleted.");
        LoadPayments();
    }

    private void OnSearch(object? sender, EventArgs e)
    {
        var results = _view.SearchAllChecked
            ? _service.GetAll()
            : _service.Search(_view.SearchTerm);

        _view.LoadPayments(results);
    }

    private void OnSelected(object? sender, EventArgs e)
    {
        var dto = _service.GetById(_view.SelectedPaymentId);
        if (dto != null)
            _view.SetFields(dto);
    }
}
