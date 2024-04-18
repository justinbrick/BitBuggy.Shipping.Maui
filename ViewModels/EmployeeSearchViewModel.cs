using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.ViewModels;
public class EmployeeSearchViewModel
{
    public static string[] StatusChoices { get; } = Enum
        .GetNames(typeof(Shipping.Model.Status)) 
        .Select(name => string.Join("", name.Select(c => char.IsUpper(c) ? " " + c : c.ToString())).TrimStart(' '))
        .ToArray();


}
