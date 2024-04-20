
using BitBuggy.Shipping.Maui.Shipping.Model;
using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui.Views;

public partial class TrackingPage : ContentPage
{
    private readonly TrackingViewModel _tracking;
	public TrackingPage(TrackingViewModel tracking)
	{
        _tracking = tracking;
        BindingContext = _tracking;
		InitializeComponent();
    }

    private async void OnAppearing(object sender, EventArgs e)
    {
        await _tracking.RetrieveDeliveriesAsync();
    }

    private void OnDeliverySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Delivery delivery && _tracking.SelectedDelivery != delivery)
        {
            _tracking.SelectedDelivery = delivery;
        }
        else
        {
            _tracking.SelectedDelivery = null;
        }
    }

    private void OnShipmentSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Shipment shipment && _tracking.SelectedShipment != shipment)
        {
            _tracking.SelectedShipment = shipment;
        }
        else
        {
            _tracking.SelectedShipment = null;
        }
    }
}