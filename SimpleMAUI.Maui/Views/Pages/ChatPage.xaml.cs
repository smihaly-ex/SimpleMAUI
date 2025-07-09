using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class ChatPage : BaseRootContentPage
{
	public ChatPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
