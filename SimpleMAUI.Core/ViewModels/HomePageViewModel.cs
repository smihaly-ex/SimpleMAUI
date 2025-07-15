using SimpleMAUI.Core.Interfaces.ViewModels;
using SimpleMAUI.Core.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Maui.ApplicationModel;
using SimpleMAUI.Core.Models.DTOs;

namespace SimpleMAUI.Core.ViewModels;

public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    public ObservableCollection<Card> Cards { get; set; } = new();
    public HomePageViewModel()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task RefreshDataAsync()
    {
        try
        {
            Uri uri = new Uri("http://localhost:7014/api/cards");
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var cardList = JsonSerializer.Deserialize<List<Card>>(content, _serializerOptions);
                if (cardList == null)
                {
                    Debug.WriteLine("No cards found.");
                    return;
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Cards.Clear();
                    foreach (var card in cardList)
                        Cards.Add(card);
                });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task AddDataAsync(CardPost card)
    {
        try
        {
            Uri uri = new Uri("http://localhost:7014/api/cards");
            string json = JsonSerializer.Serialize(card, _serializerOptions);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var addedCard = JsonSerializer.Deserialize<Card>(responseContent, _serializerOptions);
                if (addedCard != null)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Cards.Add(addedCard);
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
}
