using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
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

    public static readonly string[] Scopes = ["openid", "offline_access"];

    private readonly IPublicClientApplication _clientApplication;
    private readonly ILogger _logger;
    private bool _signedIn = false;
    private bool _deliveryStaff = false;
    private bool _managementStaff = false;
    private string? _firstName;
    private string? _lastName;
    private string? _loginFailureMessage;


    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }
    }

    public string? LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }
    }

    public string FullName
    {
        get => $"{_firstName} {_lastName}";
    }

    public string? LoginFailureMessage
    {
        get => _loginFailureMessage;
        set
        {
            if (_loginFailureMessage != value)
            {
                _loginFailureMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoginFailureMessage)));
            }
        }
    }

    public bool ManagementStaff
    {
        get => _managementStaff;
        set
        {
            if (_managementStaff != value)
            {
                _managementStaff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ManagementStaff)));
            }
        }
    }

    public bool DeliveryStaff
    {
        get => _deliveryStaff;
        set
        {
            if (_deliveryStaff != value)
            {
                _deliveryStaff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DeliveryStaff)));
            }
        }
    }

    public ICommand SignInCommand { get; }
    public ICommand SignOutCommand { get; }
    public ICommand RefreshCommand { get; }

    public AccountViewModel(IPublicClientApplication publicClient, ILogger<AccountViewModel> logger)
    {
        _clientApplication = publicClient;
        _logger = logger;
        SignInCommand = new Command(async () => await SignInAsync());
        SignOutCommand = new Command(async () => await SignOutAsync());
        RefreshCommand = new Command(async () => await LoginSilentAsync());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool SignedIn
    {
        get => _signedIn;
        set
        {
            if (_signedIn != value)
            {
                _signedIn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignedIn)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignedOut)));
            }
        }
    }

    public bool SignedOut => !SignedIn;

    private void AssignPropertiesFromPrincipal(ClaimsPrincipal? principal)
    {
        LoginFailureMessage = null;
        SignedIn = principal is not null;
        FirstName = principal?.FindFirst("given_name")?.Value;
        LastName = principal?.FindFirst("family_name")?.Value;
        string roleString = principal?.FindFirst("extension_roles")?.Value ?? string.Empty;
        string[] roles = roleString.Split(",");
        ManagementStaff = roles.Contains("SHP-STF");
        DeliveryStaff = roles.Contains("SHP-DLR");
    }

    /// <summary>
	/// Forces an interactive sign in with a "Select Account" prompt. 
	/// </summary>
	/// <returns></returns>
    public async Task SignInAsync()
    {
        try
        {
            AuthenticationResult? auth = await _clientApplication
                .AcquireTokenInteractive(Scopes)
                .ExecuteAsync();

            AssignPropertiesFromPrincipal(auth.ClaimsPrincipal);
        } catch (MsalException ex)
        {
            _logger.LogError(ex, "Failed to sign in");
            LoginFailureMessage = ex.Message;
        }
    }

    /// <summary>
    /// Signs the user out of their account if they are signed in and removes the account from the cache.
    /// </summary>
    /// <returns></returns>
    public async Task SignOutAsync()
    {
        IEnumerable<IAccount> accounts = await _clientApplication.GetAccountsAsync();
        foreach (IAccount account in accounts)
        {
            await _clientApplication.RemoveAsync(account);
        }

        AssignPropertiesFromPrincipal(null);
    }

    /// <summary>
    /// Attempts to log the user in silently.
    /// </summary>
    /// <returns></returns>
    public async Task LoginSilentAsync()
    {
        IAccount? account = (await _clientApplication.GetAccountsAsync()).FirstOrDefault();

        if (account == null)
        {
            return;
        }

        try
        {
            AuthenticationResult auth = await _clientApplication
                .AcquireTokenSilent(Scopes, account)
                .ExecuteAsync();

            AssignPropertiesFromPrincipal(auth.ClaimsPrincipal);
        }
        catch (MsalUiRequiredException) { }
    }
}
