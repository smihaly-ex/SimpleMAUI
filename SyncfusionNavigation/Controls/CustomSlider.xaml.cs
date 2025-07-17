using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;

namespace SyncfusionNavigation.Controls;
public partial class CustomSlider : ContentView
{
    private readonly Frame _trackFrame;
    private readonly Border _thumbBorder;
    private readonly PanGestureRecognizer _panGesture;

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(double), typeof(CustomSlider), 0.5, // Default to middle
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CustomSlider)bindable).UpdateThumbPosition();
        });

    public static readonly BindableProperty MinimumProperty =
        BindableProperty.Create(nameof(Minimum), typeof(double), typeof(CustomSlider), 0.0);

    public static readonly BindableProperty MaximumProperty =
        BindableProperty.Create(nameof(Maximum), typeof(double), typeof(CustomSlider), 1.0);

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public double Minimum
    {
        get => (double)GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    public double Maximum
    {
        get => (double)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public CustomSlider()
    {
        // Create track using Frame instead of BoxView
        _trackFrame = new Frame
        {
            BackgroundColor = Color.FromArgb("#b0deff"),
            HeightRequest = 35,
            CornerRadius = 5,
            Padding = 0,
            HasShadow = false,
            BorderColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.Fill
        };

        // Create thumb using Border instead of BoxView
        _thumbBorder = new Border
        {
            BackgroundColor = Color.FromArgb("#0095ff"),
            WidthRequest = 30,
            HeightRequest = 30,
            StrokeThickness = 0,
            Stroke = Colors.Transparent,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };

        // Set the corner radius for the thumb (now works properly with Border)
        _thumbBorder.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(5)
        };

        // Create a container
        var grid = new Grid
        {
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Transparent // Ensure grid background is transparent
        };

        grid.Add(_trackFrame);
        grid.Add(_thumbBorder);

        Content = grid;

        // Add pan gesture for dragging
        _panGesture = new PanGestureRecognizer();
        _panGesture.PanUpdated += OnPanUpdated;
        _thumbBorder.GestureRecognizers.Add(_panGesture);

        // Handle size changes
        SizeChanged += (sender, args) => UpdateThumbPosition();
    }

    private void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // Capture initial position if needed
                break;

            case GestureStatus.Running:
                var newX = _thumbBorder.TranslationX + e.TotalX;
                var trackWidth = _trackFrame.Width;
                var maxX = trackWidth - _thumbBorder.Width;

                if (maxX <= 0)
                    return;

                // Clamp and apply translation
                newX = Math.Max(0, Math.Min(maxX, newX));
                _thumbBorder.TranslationX = newX;

                // Update Value based on the thumb's relative position
                Value = Minimum + (Maximum - Minimum) * (newX / maxX);
                break;

            case GestureStatus.Completed:
                // Handle completion if needed
                break;
        }
    }

    private void UpdateThumbPosition()
    {
        if (Width <= 0 || _thumbBorder == null) return;

        var trackWidth = _trackFrame.Width;
        var maxX = trackWidth - _thumbBorder.Width;

        var normalizedValue = (Value - Minimum) / (Maximum - Minimum);
        var newX = normalizedValue * maxX;

        if (!double.IsNaN(newX) && !double.IsInfinity(newX))
        {
            _thumbBorder.TranslationX = newX;
        }
    }
}