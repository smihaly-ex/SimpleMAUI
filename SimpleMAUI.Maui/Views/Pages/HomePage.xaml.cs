using SimpleMAUI.Core.Interfaces.Services;
using SimpleMAUI.Core.Interfaces.ViewModels;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class HomePage : BaseRootContentPage
{
    private readonly IHomePageViewModel _viewModel;
    public HomePage(IHomePageViewModel viewModel, INavigationService navigationService) : base(navigationService)
	{
		BindingContext = viewModel;
        _viewModel = viewModel;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.RefreshDataAsync();
    }
}
