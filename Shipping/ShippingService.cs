using BitBuggy.Shipping.Maui.Shipping.Api;
using BitBuggy.Shipping.Maui.Shipping.Client;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.Shipping;

#nullable enable

/// <summary>
/// Info for authorization on Shipping API. 
/// </summary>
public sealed class ShippingService(AccountAuthorizationService accountAuthorizationService)
{
    private readonly AccountAuthorizationService _authorization = accountAuthorizationService;
    public static readonly string[] Scopes = ["https://bitbuggy.dev/shipping/Shipment.Write"];
    public async Task<Configuration?> GetConfigurationAsync()
    {
        AuthenticationResult? authenticationResult = await _authorization.GetAuthenticationAsync(Scopes);
        if (authenticationResult is null)
        {
            return null;
        }

        return new Configuration
        {
            AccessToken = authenticationResult.AccessToken,
            BasePath = "https://localhost:8000"
        };
    }

    public async Task<MeApi?> GetMeAsync()
    {
        Configuration? configuration = await GetConfigurationAsync();
        if (configuration is null)
        {
            return null;
        }

        return new MeApi(configuration);
    }

    public async Task<OrdersApi?> GetOrdersAsync()
    {
        Configuration? configuration = await GetConfigurationAsync();
        if (configuration is null)
        {
            return null;
        }

        return new OrdersApi(configuration);
    }

    public async Task<ShipmentsApi?> GetShipmentsAsync()
    {
        Configuration? configuration = await GetConfigurationAsync();
        if (configuration is null)
        {
            return null;
        }

        return new ShipmentsApi(configuration);
    }
}
