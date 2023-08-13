namespace ModelingEvolution.MauiControls.Toggle;

public interface IToggleButton
{
    void UpdateTrackColor(MColor color);
    void UpdateThumbColor(MColor color);
    void UpdateIsEnabled(bool isEnabled);
    void Toggle(bool isOn);
}
