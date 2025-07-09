using CommunityToolkit.Mvvm.ComponentModel;
using SimpleMAUI.Maui.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMAUI.Maui.Extension
{
    public class Translator : INotifyPropertyChanged
    {
        public CultureInfo CultureInfo { get; set; }
        public static Translator Instance { get; set; } = new Translator();
        public string this[string key]
        {
            get
            {
                return Strings.ResourceManager.GetString(key, CultureInfo);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
