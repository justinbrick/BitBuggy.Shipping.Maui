using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui;
internal class ShippingService
{
    private readonly HttpClient _client = new()
    { 
        // FastAPI & Uvicorn server
        BaseAddress = new Uri("https://localhost:8000")
    };


}
