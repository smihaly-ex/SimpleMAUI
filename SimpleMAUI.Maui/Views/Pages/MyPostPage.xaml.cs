using SimpleMAUI.Core.Interfaces.Services;
using SimpleMAUI.Core.Interfaces.ViewModels;
using SimpleMAUI.Core.Models.DTOs;

namespace SimpleMAUI.Maui.Views.Pages;

public partial class MyPostPage : BaseRootContentPage
{
    private readonly IHomePageViewModel _viewModel;
    private Stream? _imageStream;
    public MyPostPage(INavigationService navigationService, IHomePageViewModel viewModel) : base(navigationService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choose your photo"
            });

            if (result == null)
            {
                await DisplayAlert("Info", "You didn't select a photo.", "OK");
                return;
            }

            var stream = await result.OpenReadAsync();
            if (stream == null)
            {
                await DisplayAlert("Error", "Invalid photo", "OK");
                return;
            }

            _imageStream = await result.OpenReadAsync();

            PreviewImage.Source = ImageSource.FromStream(() => stream);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }

    private async void OnPostClicked(object sender, EventArgs e)
    {
        try
        {
            if (_imageStream == null)
            {
                await DisplayAlert("Error", "Please select an image.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(TitleEntry.Text) || string.IsNullOrWhiteSpace(DescEntry.Text))
            {
                await DisplayAlert("Error", "Please fill out all fields.", "OK");
                return;
            }

            // Convert image stream to Base64
            _imageStream.Position = 0;
            using var ms = new MemoryStream();
            await _imageStream.CopyToAsync(ms);
            var base64Image = Convert.ToBase64String(ms.ToArray());

            var post = new CardPost
            {
                Title = TitleEntry.Text,
                Text = DescEntry.Text,
                Image = base64Image
            };

            await _viewModel.AddDataAsync(post);

            await DisplayAlert("Success", "Post added!", "OK");

            // Optional: clear inputs
            TitleEntry.Text = string.Empty;
            DescEntry.Text = string.Empty;
            PreviewImage.Source = null;
            _imageStream = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }
}