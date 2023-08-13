using ModelingEvolution.MauiControls.Platforms.Android;
using View = Android.Views.View;

namespace ModelingEvolution.MauiControls.Toggle;

public partial class ToggleButtonHandler
{
    protected override NativeToggleButton CreatePlatformView() => new(Context);
    ButtonClickListener ClickListener { get; } = new();

    protected override void ConnectHandler(NativeToggleButton platformView)
    {
        platformView.SetOnClickListener(ClickListener);
        ClickListener.Handler = this;
        
        base.ConnectHandler(platformView);
        
        platformView.Toggle(VirtualView.IsToggled);
    }

    public static void MapTrackColor(ToggleButtonHandler handler, ToggleButton toggleButton)
    {
        handler.PlatformView.UpdateTrackColor(toggleButton.TrackColor);
    }

    public static void MapThumbColor(ToggleButtonHandler handler, ToggleButton toggleButton)
    {
        handler.PlatformView.UpdateThumbColor(toggleButton.ThumbColor);
    }

    public static void MapIsEnabled(ToggleButtonHandler handler, ToggleButton toggleButton)
    {
        handler.PlatformView.UpdateIsEnabled(toggleButton.IsEnabled);
    }

    public static void MapToggled(ToggleButtonHandler handler, ToggleButton toggleButton, object args)
    {
        handler.PlatformView.Toggle(toggleButton.IsToggled);
    }

    private void OnClick()
    {
        VirtualView.Click();
    }

    class ButtonClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public ToggleButtonHandler Handler { get; set; }

        public void OnClick(View view)
        {
            Handler.OnClick();
        }
    }
}
