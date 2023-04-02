using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Globalization;
using YatzyApp.Shared.Resources;

namespace YatzyApp.Shared.Components;

public partial class CultureSelector
{
    [Inject] public required ILocalStorageService LocalStorage { get; set; }
    [Inject] public required NavigationManager Navigation { get; set; }
    [Inject] public required IStringLocalizer<Resource> T { get; set; }

    private readonly CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("fi-FI"),
    };

    private CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

    private async Task SetCulture()
    {
        await LocalStorage.SetItemAsStringAsync("culture", Culture.ToString());
        CultureInfo.DefaultThreadCurrentCulture = Culture;
        CultureInfo.DefaultThreadCurrentUICulture = Culture;
        Navigation.NavigateTo("/", true);
    }
}
