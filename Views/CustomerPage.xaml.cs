
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
        //await _trackingViewModel.RetrieveDeliveriesAsync();
    }
}