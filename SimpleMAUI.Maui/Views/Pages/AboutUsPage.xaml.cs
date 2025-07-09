using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class AboutUsPage : BaseRootContentPage
{
	public AboutUsPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
