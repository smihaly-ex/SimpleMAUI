using SimpleMAUI.Core.Interfaces.ViewModels;
using System.ComponentModel;

namespace SimpleMAUI.Core.ViewModels;

public abstract class BaseViewModel : IBaseViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
