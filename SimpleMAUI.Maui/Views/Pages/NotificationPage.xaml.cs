using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class NotificationPage : BaseRootContentPage
{
	public NotificationPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
