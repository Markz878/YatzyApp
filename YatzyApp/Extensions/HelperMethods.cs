using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace YatzyApp.Extensions;

public static class HelperMethods
{
    public static int ParsePoint(string point)
    {
        if (int.TryParse(point, out int result))
        {
            return result;
        }
        return 0;
    }

    public static async Task SetDefaultCulture(this WebAssemblyHost host)
    {
        ILocalStorageService localStorage = host.Services.GetRequiredService<ILocalStorageService>();
        string cultureString = await localStorage.GetItemAsStringAsync("culture");
        if (string.IsNullOrEmpty(cultureString))
        {
            return;
        }
        try
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureString);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load culture {cultureString}, error was {ex.Message}.");
        }
    }
}
