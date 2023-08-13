namespace ModelingEvolution.MauiControls.Color;

public static class ColorExtensionsMethods
{
    public static AColor ToAndroidColor(this MColor mauiColor)
    {
        mauiColor.ToRgba(out byte red, out byte green, out byte blue, out byte alpha);
        
        return new AColor(red, green, blue, alpha);
    }
    
}