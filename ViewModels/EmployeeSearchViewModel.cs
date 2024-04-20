using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BitBuggy.Shipping.Maui.Shipping;
using BitBuggy.Shipping.Maui.Shipping.Model;

namespace BitBuggy.Shipping.Maui.ViewModels;
public class EmployeeSearchViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly ShippingService _shipping;

    public ICommand SearchDelivery { get; }
    public static string[] StatusChoices { get; } = Enum
        .GetNames(typeof(Shipping.Model.Status)) 
        .Select(name => string.Join("", name.Select(c => char.IsUpper(c) ? " " + c : c.ToString())).TrimStart(' '))
        .ToArray();

    public async Task SearchDeliveryAsync()
    {

    }

    public EmployeeSearchViewModel(ShippingService shipping) 
    {
        _shipping = shipping;
        SearchDelivery = new Command(async ()=> await SearchDeliveryAsync());
    }
}
