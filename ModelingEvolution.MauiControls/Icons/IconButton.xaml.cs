namespace ModelingEvolution.MauiControls.Icons;

public partial class IconButton
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(MaterialIcon),
        typeof(IconButton),
        defaultValue: new MaterialIcon());

    public static readonly BindableProperty ActiveColorProperty = BindableProperty.Create(
        nameof(ActiveColor), 
        typeof(MColor),
        typeof(IconButton),
        defaultValue: Colors.Transparent);

    public static readonly BindableProperty DisabledColorProperty = BindableProperty.Create(
        nameof(DisabledColor),
        typeof(MColor),
        typeof(IconButton),
        defaultValue: Colors.Transparent);

    public IconButton()
    {
        InitializeComponent();
    }

    public MaterialIcon Icon
    {
        get => (MaterialIcon)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public MColor ActiveColor
    {
        get => (MColor)GetValue(ActiveColorProperty);
        set => SetValue(ActiveColorProperty, value);
    }

    public MColor DisabledColor
    {
        get => (MColor)GetValue(DisabledColorProperty);
        set => SetValue(DisabledColorProperty, value);
    }

    protected override void ChangeVisualState()
    {
        base.ChangeVisualState();
        Background = IsEnabled ? ActiveColor : DisabledColor;
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == IconProperty.PropertyName)
        {
            Text = (string)Icon;
        }

        if (propertyName == nameof(IsEnabled))
        {
            ChangeVisualState();
        }
    }
}