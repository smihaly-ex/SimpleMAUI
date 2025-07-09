using SimpleMAUI.Core.Models;

namespace SimpleMAUI.Core.Interfaces.ViewModels;

public interface IHomePageViewModel : IBasePageViewModel
{
    public List<Card> Cards { get; }
}
