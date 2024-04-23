using BitBuggy.Shipping.Maui.Shipping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.ViewModels;

/// <summary>
/// Contains information about the current shipment's status.
/// </summary>
class ShipmentStatusViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private bool _hasStatus = false;
    /// <summary>
    /// Whether or not the status has been loaded.
    /// Once this is marked as true, the status will be displayed.
    /// By default, this is false.
    /// </summary>
    public bool HasStatus
    {
        get => _hasStatus;
        set
        {
            if (_hasStatus != value)
            {
                _hasStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasStatus)));
            }
        }
    }

    private Status _status = Status.Pending;
    public Status Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
    }

    private string _statusMessage = string.Empty;
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            if (_statusMessage != value)
            {
                _statusMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusMessage)));
            }
        }
    }


}
