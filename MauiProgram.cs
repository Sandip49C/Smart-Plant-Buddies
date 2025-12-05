using Microsoft.Extensions.Logging;
using SmartPlantBuddy.Services;

namespace SmartPlantBuddy;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<DatabaseHelper>();
        builder.Services.AddSingleton<DatabaseRepository>();
        builder.Services.AddSingleton<SecurePinService>();
        builder.Services.AddSingleton<LocationService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}