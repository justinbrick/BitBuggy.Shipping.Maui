namespace BitBuggy.Shipping.Maui.Views;

public partial class CustomerPage : ContentPage
{
    private readonly ShippingService _shippingService;

	public CustomerPage(ShippingService shippingService)
	{
		InitializeComponent();
        _shippingService = shippingService;
    }


}