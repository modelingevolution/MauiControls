using Android.Content;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Platform;
using ModelingEvolution.MauiControls.Color;
using ModelingEvolution.MauiControls.Toggle;

namespace ModelingEvolution.MauiControls.Platforms.Android;

public class NativeToggleButton : SwitchCompat, IToggleButton
{
    public NativeToggleButton(Context context) : base(context)
    {
    }

    public void UpdateTrackColor(MColor color)
    {
        TrackDrawable?.SetColorFilter(color.ToAndroidColor(), FilterMode.SrcAtop);
    }

    public void UpdateThumbColor(MColor color)
    {
        ThumbDrawable?.SetColorFilter(color.ToAndroidColor(), FilterMode.SrcAtop);
    }

    public void UpdateIsEnabled(bool isEnabled)
    {
        Enabled = isEnabled;
    }

    public void Toggle(bool isOn)
    {
        Checked = isOn;
    }

    public override void Toggle()
    {
        
    }
}