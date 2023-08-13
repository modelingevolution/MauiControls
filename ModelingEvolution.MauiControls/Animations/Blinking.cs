using System.Timers;
using Timer = System.Timers.Timer;

namespace ModelingEvolution.MauiControls.Animations;

public class Blinking : IDisposable, IAnimation
{
    private readonly BlinkingOptions _blinkingOptions;
    private readonly VisualElement _elementToAnimate;
    private readonly Timer _blinkingTimer;
    private bool _isFading = true;

    public Blinking(BlinkingOptions blinkingOptions, VisualElement elementToAnimate, bool autostart = true)
    {
        _blinkingOptions = blinkingOptions;
        _elementToAnimate = elementToAnimate;

        _blinkingTimer = new Timer(_blinkingOptions.Speed);
        _blinkingTimer.Elapsed += Blink;
        _blinkingTimer.AutoReset = true;

        if (autostart)
        {
            Start();
        }
    }

    public void Start()
    {
        _blinkingTimer?.Start();
    }

    public void Stop()
    {
        _blinkingTimer?.Stop();
    }
    
    private void Blink(object sender, ElapsedEventArgs e)
    {
        if (_elementToAnimate is null)
        {
            Stop();
            return;
        }
        
        double change = (_isFading ? -1 : 1) * _blinkingOptions.OpacityChangeStep;
        _elementToAnimate.Opacity += change;

        if (_elementToAnimate.Opacity >= _blinkingOptions.MaxOpacity)
        {
            _isFading = true;
            return;
        }

        if (_elementToAnimate.Opacity <= _blinkingOptions.MinimalOpacity)
        {
            _isFading = false;
        }
    }

    public void Dispose()
    {
        Stop();
        _blinkingTimer?.Dispose();
    }
}