using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using YatzyApp.Models;
using YatzyApp.Shared.Resources;

namespace YatzyApp.Pages;

public partial class Index
{
    [Inject] public required ILocalStorageService LocalStorage { get; set; }
    [Inject] public required IStringLocalizer<Resource> T { get; set; }

    private List<PlayerModel> players = new();
    private PlayerModel newPlayer = new();
    private bool addPlayerModalVisible;
    private bool addErrorModalVisible;
    private string? erroredPointName;
    private int erroredPointValue;
    private InputText? nameInput;
    private ElementReference addPlayerButton;

    protected override async Task OnInitializedAsync()
    {
        if (await LocalStorage.ContainKeyAsync("players"))
        {
            try
            {
                players = await LocalStorage.GetItemAsync<List<PlayerModel>>("players");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not load players, error {ex.Message}");
            }
        }
    }

    public async Task SaveState(PlayerModel p)
    {
        if (p.YatzyPoints.ValidatePoints(out string? erroredPoint, out int erroredValue))
        {
            addErrorModalVisible = false;
            await LocalStorage.SetItemAsync("players", players);
        }
        else
        {
            erroredPointName = erroredPoint;
            erroredPointValue = erroredValue;
            addErrorModalVisible = true;
        }
    }

    public async Task InsertPlayer()
    {
        players.Add(newPlayer);
        addPlayerModalVisible = false;
        await SaveState(newPlayer);
        newPlayer = new PlayerModel();
        await addPlayerButton.FocusAsync();
    }

    public async Task ShowAddPlayerModal()
    {
        addPlayerModalVisible = true;
        if (nameInput?.Element is not null)
        {
            await Task.Delay(10);
            await nameInput.Element.Value.FocusAsync();
        }
    }

    public void ClearPlayers()
    {
        players.Clear();
    }

    public void ClearPoints()
    {
        foreach (PlayerModel p in players)
        {
            foreach (YatzyPoint d in p.YatzyPoints.DieNumbers)
            {
                d.Points = null;
            }
            foreach (YatzyPoint d in p.YatzyPoints.Combinations)
            {
                d.Points = null;
            }
        }
    }
}
