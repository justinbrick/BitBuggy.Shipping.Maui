using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui.Views;

public partial class AccountPage : ContentPage
{
    
    public AccountViewModel AccountViewModel { get; }


	public AccountPage(AccountViewModel accountViewModel)
	{
		AccountViewModel = accountViewModel;
		BindingContext = AccountViewModel;
		InitializeComponent();
	}	
	
}