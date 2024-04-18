
using BitBuggy.Shipping.Maui.Shipping.Model;
using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui.Views;

public partial class CustomerPage : ContentPage
{
    private readonly TrackingViewModel _trackingViewModel;
	public CustomerPage(TrackingViewModel trackingViewModel)
	{
        _trackingViewModel = trackingViewModel;
        BindingContext = _trackingViewModel;
		InitializeComponent();
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        await _trackingViewModel.RetrieveDeliveriesAsync();
    }

    private void OnDeliverySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Delivery delivery && _trackingViewModel.SelectedDelivery != delivery)
        {
            _trackingViewModel.SelectedDelivery = delivery;
        }
        else
        {
            _trackingViewModel.SelectedDelivery = null;
        }
    }
}