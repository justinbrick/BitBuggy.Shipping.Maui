using BitBuggy.Shipping.Maui.Shipping.Models;
using Java.Util;
using Microsoft.Identity.Client;
using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.ViewModels;

class ShipmentListViewModel : INotifyPropertyChanged
{
    private readonly IPublicClientApplication _clientApplication;
    public event PropertyChangedEventHandler? PropertyChanged;



}

class Shipment
{
    private ShipmentStatusViewModel? shipmentStatus;
    private UUID? shippingId;
    private string? shippingAddress;
    private string? provider;
    private string? providerShipmentID;
    private DateTime? createdDate;
    private DateTime? deliveredDate;

    public UUID? ShippingId { get => shippingId; set => shippingId = value; }
    public string? ShippingAddress { get => shippingAddress; set => shippingAddress = value; }
    public string? Provider { get => provider; set => provider = value; }
    public string? ProviderShipmentID { get => providerShipmentID; set => providerShipmentID = value; }
    public DateTime? CreatedDate { get => createdDate; set => createdDate = value; }
    public DateTime? DeliveredDate { get => deliveredDate; set => deliveredDate = value; }
}