using jjitalaS5.Repositories;
using jjitalaS5.Utils;
using Microsoft.Extensions.Logging;
#if MAUI_DEVFLOW
using Microsoft.Maui.DevFlow.Agent;
#endif

namespace jjitalaS5
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if MAUI_DEVFLOW
            builder.AddMauiDevFlowAgent();
#endif

            string dbPath = FileAccessHelper.GetLocalFilePath("uisrael.db");
            builder.Services.AddSingleton<PersonRepository>(
                s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
