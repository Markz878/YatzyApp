using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using YatzyApp.Shared.Resources;

namespace YatzyApp.Shared.Components
{
    public partial class CultureSelector
    {
        [Inject] public ILocalStorageService LocalStorage { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public IStringLocalizer<Resource> T { get; set; }

        private readonly CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("fi-FI"),
        };

        private CultureInfo Culture
        {
            get => CultureInfo.DefaultThreadCurrentCulture;
            set 
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    LocalStorage.SetItemAsStringAsync("culture", value.ToString());
                    CultureInfo.DefaultThreadCurrentCulture = value;
                    CultureInfo.DefaultThreadCurrentUICulture = value;
                    Navigation.NavigateTo("/", true);
                }
            }
        }
    }
}
