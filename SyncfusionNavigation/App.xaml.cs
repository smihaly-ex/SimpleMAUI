using SyncfusionNavigation.Pages;

namespace SyncfusionNavigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
