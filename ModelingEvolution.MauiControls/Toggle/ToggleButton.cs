namespace ModelingEvolution.MauiControls.Toggle;

public class ToggleButton : View
{
    public const string ToggleButtonOnVisualState = "On";
    public const string ToggleButtonOffVisualState = "Off";

    public static readonly BindableProperty TrackColorProperty =
        BindableProperty.Create(nameof(TrackColor), typeof(MColor), typeof(ToggleButton), Colors.Transparent);

    public static readonly BindableProperty ThumbColorProperty =
        BindableProperty.Create(nameof(ThumbColor), typeof(MColor), typeof(ToggleButton), Colors.Transparent);

    public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool),
        typeof(ToggleButton), false, propertyChanged: IsToggledPropertyChanged, defaultBindingMode: BindingMode.TwoWay);

    public event EventHandler Clicked;
    public event EventHandler Toggled;

    public ToggleButton()
    {
        Toggled += Toggle;
    }
    
    public MColor TrackColor
    {
        get => (MColor)GetValue(TrackColorProperty);
        set => SetValue(TrackColorProperty, value);
    }

    public MColor ThumbColor
    {
        get => (MColor)GetValue(ThumbColorProperty);
        set => SetValue(ThumbColorProperty, value);
    }

    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    public void Toggle(object sender = null, EventArgs args = null)
    {
        Handler?.Invoke(nameof(Toggled), IsToggled);
    }
    
    protected override void ChangeVisualState()
    {
        base.ChangeVisualState();
        switch (IsEnabled)
        {
            case true when IsToggled:
                VisualStateManager.GoToState(this, ToggleButtonOnVisualState);
                break;
            case true when !IsToggled:
                VisualStateManager.GoToState(this, ToggleButtonOffVisualState);
                break;
        }
    }

    internal void Click()
    {
        if (IsEnabled)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
    
    private static void IsToggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((ToggleButton)bindable).Toggled?.Invoke(bindable, EventArgs.Empty);
        ((ToggleButton)bindable).ChangeVisualState();
        ((IView)bindable)?.Handler?.UpdateValue(nameof(TrackColor));
    }
}