using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitBuggy.Shipping.Maui.ViewModels;

/// <summary>
/// Contains information regarding the current account. 
/// 
/// </summary>
public class AccountViewModel : INotifyPropertyChanged
{

    private readonly IPublicClientApplication _clientApplication;
    private bool _refreshed = false;

    public ICommand SignInCommand { get; }
    public ICommand SignOutCommand { get; }
    public ICommand RefreshCommand { get; }

    public AccountViewModel(IPublicClientApplication publicClient)
    {
        _clientApplication = publicClient;
        SignInCommand = new Command(async () => await SignInAsync());
        SignOutCommand = new Command(async () => await SignOutAsync());
        RefreshCommand = new Command(async () => await RefreshAsync());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool SignedIn
    {
        get => _account is not null;
    }

    private IAccount? _account;
    public IAccount? Account
    {
        get => _account;
        set
        {
            if (_account != value)
            {
                _account = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Account)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignedIn)));
            }
        }
    }

    /// <summary>
	/// Forces an interactive sign in with a "Select Account" prompt. 
	/// </summary>
	/// <returns></returns>
    public async Task SignInAsync()
    {
        AuthenticationResult? token = await _clientApplication.AcquireTokenInteractive(["User.Read"])
            .WithPrompt(Prompt.SelectAccount)
            .ExecuteAsync();

        Account = token.Account;
    }

    /// <summary>
    /// Signs the user out of their account if they are signed in and removes the account from the cache.
    /// </summary>
    /// <returns></returns>
    public async Task SignOutAsync()
    {
        if (Account is null)
            return;

        await _clientApplication.RemoveAsync(Account);
        Account = null;
    }

    /// <summary>
    /// Refreshes the current account to make sure that it is still valid.
    /// This will look to see if the public client application has any accounts registered in its cache - picks the first.
    /// </summary>
    /// <returns></returns>
    public async Task RefreshAsync()
    {
        if (_refreshed)
            return;
        _refreshed = true;

        IEnumerable<IAccount> accounts = await _clientApplication.GetAccountsAsync();

        if (!accounts.Any())
            return;

        IAccount account = accounts.First();
        Account = account;
    }
}
