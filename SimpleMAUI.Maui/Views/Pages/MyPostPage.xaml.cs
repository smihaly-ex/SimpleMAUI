using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class MyPostPage : BaseRootContentPage
{
	public MyPostPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
