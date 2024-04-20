using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BitBuggy.Shipping.Maui.Shipping;
using BitBuggy.Shipping.Maui.Shipping.Api;
using BitBuggy.Shipping.Maui.Shipping.Model;

namespace BitBuggy.Shipping.Maui.ViewModels;
public class EmployeeSearchViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private readonly ShippingService _shipping;
    private bool _dateDescending = true;
    private string _trackingId = string.Empty;
    private string _deliveryId = string.Empty;
    private Status? _status = null;
    private Provider? _provider = null;

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


    public ICommand SearchDelivery { get; }
    public static string[] StatusChoices { get; } = Enum
        .GetNames(typeof(Shipping.Model.Status)) 
        .Select(name => string.Join("", name.Select(c => char.IsUpper(c) ? " " + c : c.ToString())).TrimStart(' '))
        .ToArray();

    public async Task SearchDeliveryAsync()
    {
        ShipmentsApi? api = await _shipping.GetShipmentsAsync();
        if (api is null)
        {
            return;
        }


    }

    public EmployeeSearchViewModel(ShippingService shipping) 
    {
        _shipping = shipping;
        SearchDelivery = new Command(async ()=> await SearchDeliveryAsync());
    }
}
