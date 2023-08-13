using Microsoft.Maui.Handlers;
using ModelingEvolution.MauiControls.Toggle;

namespace ModelingEvolution.MauiControls;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder AddModelingEvolutionMauiControls(this MauiAppBuilder appBuilder)
    {
        appBuilder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler(typeof(ToggleButton), typeof(ToggleButtonHandler));
        });
        
        return appBuilder;
    }
}