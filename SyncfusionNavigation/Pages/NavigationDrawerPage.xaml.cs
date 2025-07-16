using Syncfusion.Maui.Toolkit.NavigationDrawer;

namespace SyncfusionNavigation.Pages;

public partial class NavigationDrawerPage : ContentPage
{
    public NavigationDrawerPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        listView.ItemsSource = new List<string>
        {
            "Home",
            "My Doors"
        };
        LoadPage("Home");
    }

    private void hamburgerButton_Clicked(object sender, EventArgs e)
    {
        navigationDrawer.ToggleDrawer();
    }

    private void DrawerListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is string selectedItem)
        {
            LoadPage(selectedItem);
            navigationDrawer.IsOpen = false;
            listView.SelectedItem = null;
        }
    }

    private void LoadPage(string pageName)
    {
        PageTitle.Text = pageName;

        switch (pageName)
        {
            case "Home":
                PageHost.Content = new MainPage(); // ContentPage -> convert to ContentView if needed
                break;

            case "My Doors":
                PageHost.Content = new MyDoorsPage(); // same here
                break;
        }
    }
}