using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui.Views;

public partial class AccountPage : ContentPage
{

    private readonly AccountViewModel _account;


	public AccountPage(AccountViewModel account)
	{
		_account = account;
		BindingContext = _account;
		InitializeComponent();
	}

    private async void OnAppearing(object sender, EventArgs e)
    {
        await _account.LoginSilentAsync();
    }
	
}