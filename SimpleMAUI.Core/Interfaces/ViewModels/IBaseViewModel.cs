using System.ComponentModel;

namespace SimpleMAUI.Core.Interfaces.ViewModels;

public interface IBaseViewModel : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}