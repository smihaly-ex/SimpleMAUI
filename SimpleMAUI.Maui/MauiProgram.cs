using SimpleMAUI.Core.Interfaces.Services;
using SimpleMAUI.Core.Interfaces.ViewModels;
using SimpleMAUI.Core.ViewModels;
using SimpleMAUI.Maui.Services;
using SimpleMAUI.Maui.Views.Pages;
using Microsoft.Extensions.Logging;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace SimpleMAUI.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
                fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
            });

        builder.UseSimpleShell();
        builder.UseSimpleToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

#if IOS || ANDROID
        builder.DisplayContentBehindBars();
#endif
#if ANDROID
        builder.SetDefaultStatusBarAppearance(Colors.Transparent, false);
#endif

        builder.Services.AddTransient<AppShell>();

        builder.Services.AddTransient<AboutUsPage>();
        builder.Services.AddTransient<ChatPage>();
        builder.Services.AddTransient<FaqPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<InviteFriendsPage>();
        builder.Services.AddTransient<MyPostPage>();
        builder.Services.AddTransient<NotificationPage>();
        builder.Services.AddTransient<SupportPage>();
        builder.Services.AddTransient<LanguagePage>();

        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddTransient<IHomePageViewModel, HomePageViewModel>();

        return builder.Build();
    }
}
