using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using BitBuggy.Shipping.Maui.ViewModels;

namespace BitBuggy.Shipping.Maui;

public static class MauiProgram
{
    const string ClientId = "392123fa-9f8a-4001-99fa-ab1a3d51a9df";
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
            // https://learn.microsoft.com/en-us/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/maui/authentication
#if ANDROID
            // Android Devices
            return PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(AadAuthorityAudience.AzureAdAndPersonalMicrosoftAccount)
                .WithRedirectUri($"msal{ClientId}://auth")
                .WithParentActivityOrWindow(() => Platform.CurrentActivity)
                .Build();
#elif IOS
            // iOS - Uses AdalCache for MSAL
            return PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(AadAuthorityAudience.AzureAdAndPersonalMicrosoftAccount)
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .WithRedirectUri($"msal{ClientId}://auth")
                .Build();
#else
            // Windows, macOS, Linux
            return PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(AadAuthorityAudience.AzureAdAndPersonalMicrosoftAccount)
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
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
            .AddSingleton<AccountPage>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}