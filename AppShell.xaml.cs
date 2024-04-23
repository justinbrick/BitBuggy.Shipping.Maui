using BitBuggy.Shipping.Maui.ViewModels;
using System.ComponentModel;

namespace BitBuggy.Shipping.Maui;

public partial class AppShell : Shell
{
    private readonly AccountViewModel _accountViewModel;

    public AppShell(AccountViewModel accountViewModel)
    {
        _accountViewModel = accountViewModel;
        BindingContext = _accountViewModel;
        _accountViewModel.PropertyChanged += OnAccountViewModelPropertyChanged;
        InitializeComponent();
    }

    private void OnAccountViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AccountViewModel.SignedIn))
        {
            EmployeeTab.FlyoutItemIsVisible = _accountViewModel.ManagementStaff;
            ForceLayout();
        }
    }


    private async void OnAppearing(object sender, EventArgs e)
    {
        await _accountViewModel.LoginSilentAsync();
    }
}