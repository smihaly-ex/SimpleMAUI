using SimpleMAUI.Maui.Extension;
using System.Globalization;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class LanguagePage : ContentPage
{
	public LanguagePage()
	{
		InitializeComponent();
	}

	public void hu_Clicked(object sender, EventArgs e)
	{
		Translator.Instance.CultureInfo = new CultureInfo("hu");
		Translator.Instance.OnPropertyChanged();
    }

	public void en_Clicked(object sender, EventArgs e)
	{
		Translator.Instance.CultureInfo = new CultureInfo("en");
		Translator.Instance.OnPropertyChanged();
    }

}