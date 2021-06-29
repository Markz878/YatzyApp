using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YatzyApp.Models;

namespace YatzyApp.Pages
{
    public partial class Index
    {
        [Inject] public ILocalStorageService LocalStorage { get; set; }
        public List<PlayerModel> Players { get; set; } = new List<PlayerModel>();
        public PlayerModel NewPlayer { get; set; } = new PlayerModel();
        public bool AddPlayerModalVisible { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (await LocalStorage.ContainKeyAsync("players"))
            {
                try
                {
                    Players = await LocalStorage.GetItemAsync<List<PlayerModel>>("players");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Could not load players, error {e.Message}");
                }
            }
        }
        public async Task SaveState()
        {
            await LocalStorage.SetItemAsync("players", Players);
        }

        public void InsertPlayer()
        {
            Players.Add(NewPlayer);
            AddPlayerModalVisible = false;
            NewPlayer = new PlayerModel();
        }

        public void ClearPlayers()
        {
            Players.Clear();
        }

        public void ClearPoints()
        {
            foreach (var p in Players)
            {
                foreach (var d in p.YatzyPoints.DieNumbers)
                {
                    d.Points = null;
                }
                foreach (var d in p.YatzyPoints.Combinations)
                {
                    d.Points = null;
                }
            }
        }
    }
}
