using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui;

public sealed class AccountAuthorizationService
    (IPublicClientApplication publicClient)
{
    private readonly IPublicClientApplication _publicClient = publicClient;

    public async Task<AuthenticationResult?> GetAuthenticationAsync(string[] scopes)
    {
        IEnumerable<IAccount> accounts = await _publicClient.GetAccountsAsync();
        IAccount? firstAccount = accounts.FirstOrDefault();

        AuthenticationResult? result;
        try
        {
            result = await _publicClient
                .AcquireTokenSilent(scopes, firstAccount)
                .ExecuteAsync();
        }
        catch (MsalUiRequiredException)
        {
            result = await LoginAsync(scopes, firstAccount);
        }

        return result;
    }

    public async Task<AuthenticationResult?> LoginAsync(string[] scopes, IAccount? account = default)
    {
        try
        {
            // If the account exists, try to use cached variable & no prompt.
            // Otherwise, prompt the user to login.
            if (account is not null)
            {
                return await _publicClient
                    .AcquireTokenInteractive(scopes)
                    .WithAccount(account)
                    .WithPrompt(Prompt.NoPrompt)
                    .ExecuteAsync();
            }
            else
            {
                // No account found - go to part required for login.
                // Adds to the stack so once logged in, they can back out to what they were doing for minimum disruption.
                // Might not need to navigate to account page - if we force a sign in, they choose account there.
                // This could be a scenario where if they wish to change the account afterwards, they can just navigate to the account page then.
                return await _publicClient
                    .AcquireTokenInteractive(scopes)
                    .ExecuteAsync();
            }
        }
        catch (MsalException)
        {
            await Shell.Current.GoToAsync("/account");
        }
        
        return null;
    }
}
