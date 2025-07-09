using SimpleMAUI.Core.Interfaces.Services;

namespace SimpleMAUI.Maui.Views.Pages;

public class BaseRootContentPage : BaseContentPage
{
	public BaseRootContentPage(INavigationService navigationService) : base(navigationService)
    {
	}

    protected override void OnSafeAreaChanged(Thickness safeArea)
    {
        Padding = new Thickness(safeArea.Left, 0, safeArea.Right, safeArea.Bottom);
    }
}
