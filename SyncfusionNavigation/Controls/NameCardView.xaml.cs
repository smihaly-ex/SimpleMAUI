namespace SyncfusionNavigation.Controls;

public partial class NameCardView : ContentView
{
    public static readonly BindableProperty NameTextProperty =
            BindableProperty.Create(nameof(NameText), typeof(string), typeof(NameCardView), default(string), propertyChanged: OnNameTextChanged);

    public string NameText
    {
        get => (string)GetValue(NameTextProperty);
        set => SetValue(NameTextProperty, value);
    }

    public NameCardView()
    {
        InitializeComponent();
    }

    private static void OnNameTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is NameCardView view && newValue is string name)
        {
            view.NameLabel.Text = name;
        }
    }
}