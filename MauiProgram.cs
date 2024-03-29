using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using BitBuggy.Shipping.Maui.ViewModels;
using BitBuggy.Shipping.Maui.Views;

namespace BitBuggy.Shipping.Maui;

public static class MauiProgram
{
    const string ClientId = "8fb6f658-02b8-4a68-84ae-6d0a8b7a865e";
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IPublicClientApplication>(services =>
        {
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder
                .Create(ClientId)
                // B2C: Tenant Name: bitbuggy, Tenant ID: bitbuggy.onmicrosoft.com, use tfp
                .WithB2CAuthority("https://bitbuggy.b2clogin.com/tfp/bitbuggy.onmicrosoft.com/B2C_1_BitBuggyLogin")
                .WithRedirectUri($"msal{ClientId}://auth");

            // https://learn.microsoft.com/en-us/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/maui/authentication
#if ANDROID
            // Android Devices
            return builder
                .WithParentActivityOrWindow(() => Platform.CurrentActivity)
                .Build();
#elif IOS
            // iOS - Uses AdalCache for MSAL
            return builder
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .Build();
#else
            // Windows, macOS, Linux
            return builder
                .WithRedirectUri("https://bitbuggy.b2clogin.com/oauth2/nativeclient")
                .Build();
#endif
        });

        // Services
        builder.Services
            .AddSingleton<ShippingService>();

        // Static Viewmodels
        builder.Services
            .AddSingleton<AccountViewModel>(); 

        // Pages
        builder.Services
            .AddSingleton<MainPage>()
            .AddSingleton<AccountPage>()
            .AddSingleton<CustomerPage>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}