using SimpleMAUI.Core.Models;
using System.Collections.ObjectModel;

namespace SimpleMAUI.Core.Interfaces.ViewModels;

public interface IHomePageViewModel
{
    ObservableCollection<Card> cards { get; }
}
