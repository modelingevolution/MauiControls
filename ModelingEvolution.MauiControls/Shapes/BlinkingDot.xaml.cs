using ModelingEvolution.MauiControls.Animations;

namespace ModelingEvolution.MauiControls.Shapes;

public partial class BlinkingDot : IDisposable
{
    public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color), typeof(MColor), typeof(BlinkingOptions), Colors.Transparent);

    private readonly Blinking _blinking;
    
    public BlinkingDot()
    {
        InitializeComponent();

        _blinking = new Blinking(new BlinkingOptions
        {
            Speed = TimeSpan.FromMilliseconds(150),
            MinimalOpacity = 0.6
        }, Dot);
    }

    public MColor Color
    {
        get => (MColor)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    
    public void Dispose()
    {
        _blinking?.Dispose();
    }
}