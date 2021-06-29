using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace YatzyApp.Extensions
{
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
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            var cultureString = await localStorage.GetItemAsStringAsync("culture");
            if (string.IsNullOrEmpty(cultureString))
            {
                return;
            }
            CultureInfo culture;
            try
            {
                culture = CultureInfo.GetCultureInfo(cultureString);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not load culture {cultureString}, error was {ex.Message}.");
            }

        }
    }
}
