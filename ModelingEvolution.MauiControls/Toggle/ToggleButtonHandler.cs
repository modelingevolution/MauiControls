using Microsoft.Maui.Handlers;

namespace ModelingEvolution.MauiControls.Toggle;

public partial class ToggleButtonHandler : ViewHandler<ToggleButton, Platforms.Android.NativeToggleButton>
{
    public static readonly PropertyMapper<ToggleButton, ToggleButtonHandler> ToggleButtonMapper = new()
    {
        [nameof(ToggleButton.TrackColor)] = MapTrackColor,
        [nameof(ToggleButton.ThumbColor)] = MapThumbColor,
        [nameof(ToggleButton.IsEnabled)] = MapIsEnabled
    };

    public static readonly CommandMapper<ToggleButton, ToggleButtonHandler> ToggleButtonCommandMapper = new()
    {
        [nameof(ToggleButton.Toggled)] = MapToggled
    };

    public ToggleButtonHandler() : base(ToggleButtonMapper, ToggleButtonCommandMapper)
    {
    }
}