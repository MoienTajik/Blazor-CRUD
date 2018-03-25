using BzHost.Client.Services;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BzHost.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(providers =>
            {
                providers.AddSingleton<ProductService>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}