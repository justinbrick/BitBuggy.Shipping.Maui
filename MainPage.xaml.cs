namespace BitBuggy.Shipping.Maui;

public partial class MainPage : ContentPage
{
    int count = 0;
    private readonly ShippingService? _shippingService;
    public MainPage(ShippingService shippingService)
    {   
        _shippingService = shippingService;
        InitializeComponent();
    }
}