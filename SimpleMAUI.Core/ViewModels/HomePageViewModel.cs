using SimpleMAUI.Core.Interfaces.ViewModels;
using SimpleMAUI.Core.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace SimpleMAUI.Core.ViewModels;

public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
{
    public ObservableCollection<Card> cards { get; set; } = new();
    public HomePageViewModel()
    {
        _ = LoadCardsAsync();
    }
    private async Task LoadCardsAsync()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://localhost:7014/api/cards");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var cards = JsonSerializer.Deserialize<List<Card>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            this.cards = new ObservableCollection<Card>(cards ?? new List<Card>());
        }
        else
        {
            Console.WriteLine($"Failed to get cards: {response.StatusCode}");
        }
    }
}
