using Microsoft.UI.Xaml;
using System.Windows.Controls;

namespace BitBuggy.Shipping.Maui.Views;

public partial class CustomerPage : ContentPage
{
    private readonly ShippingService _shippingService;

	public CustomerPage(ShippingService shippingService)
	{
		InitializeComponent();
        _shippingService = shippingService;
        
        
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        //api request for orders
    }
}