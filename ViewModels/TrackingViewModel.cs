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
    private Delivery? _selectedDelivery;
    private Shipment? _selectedShipment;
    private ShipmentStatus? _status;


    public ShipmentStatus? SelectedShipmentStatus
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

    public Delivery? SelectedDelivery
    {
        get => _selectedDelivery;
        set
        {
            if (_selectedDelivery != value)
            {
                _selectedDelivery = value;
                OnPropertyChanged();
            }
        }
    }

    public Shipment? SelectedShipment
    {
        get => _selectedShipment;
        set
        {
            if (_selectedShipment != value)
            {
                _selectedShipment = value;
                OnPropertyChanged();
                GetShipmentStatus.Execute(null);
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
        GetShipmentStatus = new Command(async () => await GetShipmentStatusAsync());
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //public ICommand GetName { get; }
    public ICommand RetrieveDeliveries { get; }
    public ICommand NextOrder { get; }
    public ICommand GetShipmentStatus { get; }


    private async Task NextOrderAsync()
    {
        throw new NotImplementedException();
    }

    private async Task GetShipmentStatusAsync()
    {
        // TODO: API Implementation
        if (SelectedShipment is null)
        {
            SelectedShipmentStatus = null;
            return;
        }

        SelectedShipmentStatus = GenerateRandomStatus(SelectedShipment);
    }

    public async Task RetrieveDeliveriesAsync()
    {
        //MeApi? me = await _shipping.GetMeAsync();
        //if (me is null)
        //{
        //    return;
        //}

        // await me.GetPersonalDeliveriesAsync();
        List<Delivery> deliveryList = GenerateRandomDeliveries().ToList();

        DeliveryList = new(deliveryList);
    }

    // TEST ONLY THINGS - REMOVE LATER
    private readonly static Random _random = new();

    private static IEnumerable<Delivery> GenerateRandomDeliveries()
    {
        return Enumerable
            .Range(0, _random.Next(10))
            .Select(_ =>
            {
                return new Delivery(
                    deliveryId: Guid.NewGuid(),
                    orderId: Guid.NewGuid(),
                    createdAt: DateTime.Now.AddSeconds(_random.NextInt64(50000)),
                    deliverySla: SLA.Standard,
                    shipments: GenerateRandomShipments().ToList()
                );
            });
    }
    private static IEnumerable<Shipment> GenerateRandomShipments()
    {
        return Enumerable
            .Range(0, _random.Next(10))
            .Select(_ =>
            {
                return new Shipment(
                    shipmentId: Guid.NewGuid(),
                    fromAddress: "From Address",
                    shippingAddress: "Shipping Address",
                    provider: Provider.Ups,
                    providerShipmentId: "Provider Shipment Id",
                    createdAt: DateTime.Now,
                    items: [
                        new ShipmentItem(1, 5)
                    ]
                );
            });
    }

    private readonly static List<Status> Statuses = [.. Enum.GetValues<Status>()];
    private static ShipmentStatus GenerateRandomStatus(Shipment shipment)
    {
        return new ShipmentStatus(
            shipmentId: shipment.ShipmentId,
            expectedAt: shipment.CreatedAt.AddHours(24),
            updatedAt: DateTime.Now,
            deliveredAt: DateTime.MinValue,
            message: Statuses[_random.Next(Statuses.Count)]
        );
    }
}