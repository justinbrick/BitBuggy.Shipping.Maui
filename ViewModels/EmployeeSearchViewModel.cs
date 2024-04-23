using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using BitBuggy.Shipping.Maui.Converters;
using BitBuggy.Shipping.Maui.Shipping;
using BitBuggy.Shipping.Maui.Shipping.Api;
using BitBuggy.Shipping.Maui.Shipping.Model;

namespace BitBuggy.Shipping.Maui.ViewModels;
public class EmployeeSearchViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand SearchDelivery { get; }

    private const int pageSize = 50;
    private int _page = 0;
    private readonly ShippingService _shipping;
    private bool _dateDescending = true;
    private string _trackingId = string.Empty;
    private string _deliveryId = string.Empty;
    private string _fromAddress = string.Empty;
    private string _toAddress = string.Empty;
    private Status? _status = null;
    private Provider? _provider = null;
    private ObservableCollection<Shipment> _shipments = [];

    public EmployeeSearchViewModel(ShippingService shipping)
    {
        _shipping = shipping;
        SearchDelivery = new Command(async () => await SearchDeliveryAsync());
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool DateDescending
    {
        get => _dateDescending;
        set
        {
            if (_dateDescending != value)
            {
                _dateDescending = value;
                OnPropertyChanged();
            }
        }
    }

    public string TrackingId
    {
        get => _trackingId;
        set
        {
            if (_trackingId != value)
            {
                _trackingId = value;
                OnPropertyChanged();
            }
        }
    }

    public string DeliveryId
    {
        get => _deliveryId;
        set
        {
            if (_deliveryId != value)
            {
                _deliveryId = value;
                OnPropertyChanged();
            }
        }
    }

    public string FromAddress
    {
        get => _fromAddress;
        set
        {
            if (_fromAddress != value)
            {
                _fromAddress = value;
                OnPropertyChanged();
            }
        }
    }

    public string ToAddress
    {
        get => _toAddress;
        set
        {
            if (_toAddress != value)
            {
                _toAddress = value;
                OnPropertyChanged();
            }
        }
    }

    public Status? Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }

    public Provider? Provider
    {
        get => _provider;
        set
        {
            if (_provider != value)
            {
                _provider = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<Shipment> Shipments
    {
        get => _shipments;
        set
        {
            if (_shipments != value)
            {
                _shipments = value;
                OnPropertyChanged();
            }
        }
    }

    public static readonly string[] StatusChoices = [
        " ", 
        ..Enum.GetValues<Status>()
            .Select(value => EnumStringConverter.ConvertToString(value))
    ];

    public static readonly string[] ProviderChoices = [
        " ",
        .. Enum.GetValues<Provider>()
            .Select(value => EnumStringConverter.ConvertToString(value))
    ];

    public async Task SearchDeliveryAsync()
    {
        ShipmentsApi? api = await _shipping.GetShipmentsAsync();
        if (api is null)
        {
            return;
        }

        string? from = string.IsNullOrEmpty(FromAddress) ? null : FromAddress;
        string? to = string.IsNullOrEmpty(ToAddress) ? null : ToAddress;
        string? trackingId = string.IsNullOrEmpty(TrackingId) ? null : TrackingId;
        string? deliveryId = string.IsNullOrEmpty(DeliveryId) ? null : DeliveryId;

        List<Shipment> shipments = await api.GetShipmentsAsync(
            fromAddress: from,
            shippingAddress: to,
            status: Status,
            provider: Provider,
            deliveryId: deliveryId,
            trackingId: trackingId
        );

        Shipments.Clear();

        foreach(Shipment shipment in shipments)
        {
            Shipments.Add(shipment);
        }
    }
}
