using SimpleMAUI.Maui.Extension;
using System.Globalization;

namespace SimpleMAUI.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Translator.Instance.CultureInfo = new CultureInfo("hu");
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        MainPage = this.Handler.MauiContext.Services.GetRequiredService<AppShell>();
    }
}
