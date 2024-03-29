using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using YatzyApp.Extensions;

namespace YatzyApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddLocalization();
        WebAssemblyHost host = builder.Build();
        await host.SetDefaultCulture();
        await host.RunAsync();
    }
}
