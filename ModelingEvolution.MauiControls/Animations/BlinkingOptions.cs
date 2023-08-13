namespace ModelingEvolution.MauiControls.Animations;

public readonly struct BlinkingOptions
{
    public BlinkingOptions()
    {
    }

    public TimeSpan Speed { get; init; } = TimeSpan.FromMilliseconds(100);
    public double MinimalOpacity { get; init; } = .5;
    public double MaxOpacity { get; init; } = 1;
    public double OpacityChangeStep { get; init; } = .1;
}
