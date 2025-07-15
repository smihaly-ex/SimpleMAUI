using SimpleMAUI.Core.Models;
using SimpleMAUI.Core.Models.DTOs;
using System.Collections.ObjectModel;

namespace SimpleMAUI.Core.Interfaces.ViewModels;

public interface IHomePageViewModel
{
    ObservableCollection<Card> Cards { get; set; }
    Task RefreshDataAsync();
    Task AddDataAsync(CardPost card);
}
