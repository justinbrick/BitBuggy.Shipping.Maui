using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui.Views;

public partial class EmployeeView : ContentPage
{
    private readonly EmployeeSearchViewModel _searchViewModel;
	public EmployeeView(EmployeeSearchViewModel searchViewModel)
	{
        _searchViewModel = searchViewModel;
        BindingContext = _searchViewModel;
		InitializeComponent();
	}

    private async void EmployeePage_Appearing(object sender, EventArgs e)
    {
        await _searchViewModel.SearchDeliveryAsync();
    }
}