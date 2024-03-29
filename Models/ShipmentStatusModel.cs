using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.Shipping.Models;

/// <summary>
/// A model representing the current status of a shipment
/// </summary>
class ShipmentStatusModel
{
    /// <summary>
    /// An enumeration which identifies the current status of the shipment
    /// </summary>
    public enum Status
    {
        Pending,
        AtWarehouse,
        InTransit,
        Delivered,
        Returned,
        Lost
    }

}
