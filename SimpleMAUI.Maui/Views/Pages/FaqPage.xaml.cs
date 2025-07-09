using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class FaqPage : BaseRootContentPage
{
	public FaqPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
