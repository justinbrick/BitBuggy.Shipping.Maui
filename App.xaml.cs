using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui;

public partial class App : Application
{
    public App(AccountViewModel accountViewModel)
    {
        InitializeComponent();

        MainPage = new AppShell(accountViewModel);
    }
}