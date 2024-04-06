using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace BitBuggy.Shipping.Maui;

[Activity(Exported = true)]
[IntentFilter([Intent.ActionView], 
    Categories = [Intent.CategoryBrowsable, Intent.CategoryDefault],
    DataHost = "auth",
    DataScheme = $"msal{MauiProgram.ClientId}")]
public class AuthActivity : BrowserTabActivity
{
    
}