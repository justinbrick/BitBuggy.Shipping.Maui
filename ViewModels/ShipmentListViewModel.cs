using Microsoft.Identity.Client;
using MiNET.Utils;
using Org.BouncyCastle.Cms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text.Json;
using System.Windows.Input;

namespace BitBuggy.Shipping.Maui.ViewModels;

class ShipmentListViewModel : INotifyPropertyChanged
{
    private readonly IPublicClientApplication? _clientApplication;
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //public ICommand GetName { get; }
    public ICommand RetrieveOrders { get; }
    public ICommand NextOrder { get; }
    public ICommand GetAccessToken { get; }
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

    private AuthenticationResult? _accessToken;
    private string[] _orders;

    public ShipmentListViewModel(IPublicClientApplication clientApplication)
    {
        _clientApplication = clientApplication; //retrieve access token from here
        GetAccessToken = new Command(async () => await GetAccessTokenAsync());
        RetrieveOrders = new Command(async () => await RetrieveOrdersAsync());
        NextOrder = new Command(async () => await NextOrderAsync());
    }

    private async Task GetAccessTokenAsync()
    {
        try
        {
            var token = await _clientApplication.AcquireTokenSilent(["openid", "offline_access", "https://bitbuggy.onmicrosoft.com/shipping/Shipment.Write"], Account).ExecuteAsync();
            AccessToken = token;
            
        } catch (Exception ex) 
        {
            return;
        }
    }

    private async Task NextOrderAsync()
    {
        throw new NotImplementedException();
    }

    private async Task RetrieveOrdersAsync()
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken.AccessToken);
            HttpResponseMessage httpResponseMessage = await client.GetAsync(""); //insert api call for getting orders from client
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            if (responseBody != null) { _orders = JsonSerializer.Deserialize<string[]>(responseBody); }
            
        } catch (Exception ex)
        {
            return;
        }
    }

    private ObservableCollection<Shipping.Model.Shipment> _shipments = new ObservableCollection<Shipping.Model.Shipment>(); //add order(s) that should be visible on first screen, clear for next page of orders
    public ObservableCollection<Shipping.Model.Shipment> Shipments
    {
        get => _shipments;
        set
        {
            if (_shipments != value)
            {
                _shipments = value;
                OnPropertyChanged(nameof(Shipments));
            }
        }
    }

    public AuthenticationResult? AccessToken { get => _accessToken; set => _accessToken = value; }
    public string[] Orders { get => _orders; set => _orders = value; }
}

//class Shipment
//{
//    private UUID _shipment_id;
//    private string _shipping_address;
//    private string _provider;
//    private string _provider_shipment_id;
//    private DateTime _created_at;
//    private long _upc;
//    private int _stock;

//    public UUID Shipment_id { get => _shipment_id; set => _shipment_id = value; }
//    public string Shipping_address { get => _shipping_address; set => _shipping_address = value; }
//    public string Provider { get => _provider; set => _provider = value; }
//    public string Provider_shipment_id { get => _provider_shipment_id; set => _provider_shipment_id = value; }
//    public DateTime Created_at { get => _created_at; set => _created_at = value; }
//    public long Upc { get => _upc; set => _upc = value; }
//    public int Stock { get => _stock; set => _stock = value; }


//}

//class Delivery
//{
//    private UUID _delivery_id;

//}