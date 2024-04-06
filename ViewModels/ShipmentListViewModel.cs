using Microsoft.Identity.Client;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BitBuggy.Shipping.Maui.ViewModels;

class ShipmentListViewModel : INotifyPropertyChanged
{
    private readonly IPublicClientApplication? _clientApplication;
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Shipment>? _shipments;
    public ObservableCollection<Shipment> Shipments
    {
        get => _shipments;
        set
        {
            if (_shipments != value)
            {
                _shipments = value;
                OnPropertyChanged(nameof(Shipments));
            }
        }
    }
}

class Shipment
{
    
}