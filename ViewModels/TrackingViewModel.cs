using BitBuggy.Shipping.Maui.Shipping;
using BitBuggy.Shipping.Maui.Shipping.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BitBuggy.Shipping.Maui.ViewModels;

public class TrackingViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly ShippingService _shipping;
    private ObservableCollection<Shipping.Model.Delivery> _deliveryList = [];
    private ShipmentStatus? _status;

    public ShipmentStatus? Status
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

    public ObservableCollection<Shipping.Model.Delivery> DeliveryList
    {
        get => _deliveryList;
        set
        {
            if (_deliveryList != value)
            {
                _deliveryList = value;
                OnPropertyChanged();
            }
        }
    }



    public TrackingViewModel(ShippingService shipping)
    {
        _shipping = shipping;

        RetrieveDeliveries = new Command(async () => await RetrieveDeliveriesAsync());
        NextOrder = new Command(async () => await NextOrderAsync());
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //public ICommand GetName { get; }
    public ICommand RetrieveDeliveries { get; }
    public ICommand NextOrder { get; }


    private async Task NextOrderAsync()
    {
        throw new NotImplementedException();
    }

    public async Task RetrieveDeliveriesAsync()
    {
        //MeApi? me = await _shipping.GetMeAsync();
        //if (me is null)
        //{
        //    return;
        //}

        // await me.GetPersonalDeliveriesAsync();
        List<Delivery> deliveryList = [
            new Delivery(
                deliveryId: Guid.NewGuid(),
                createdAt: DateTime.Now,
                deliverySla: SLA.Standard,
                orderId: Guid.NewGuid(),
                shipments: [
                    new Shipment(
                        shipmentId: Guid.NewGuid(),
                        fromAddress: "From Address",
                        shippingAddress: "Shipping Address",
                        provider: Provider.Ups,
                        providerShipmentId: "Provider Shipment Id",
                        createdAt: DateTime.Now,
                        items: [
                            new ShipmentItem(1, 5)
                        ]
                    )
                ]
            )
        ];

        DeliveryList = new(deliveryList);
    }
}