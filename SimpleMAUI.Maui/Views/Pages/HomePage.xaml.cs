using SimpleMAUI.Core.Interfaces.Services;
using SimpleMAUI.Core.Interfaces.ViewModels;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class HomePage : BaseRootContentPage
{
	public HomePage(IHomePageViewModel viewModel, INavigationService navigationService) : base(navigationService)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}
