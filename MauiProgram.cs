using Microsoft.Extensions.Logging;

namespace gguachaminS5_2
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
            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<PersonaRepository>(s => ActivatorUtilities.CreateInstance<PersonaRepository>(s, dbPath));

            builder.Logging.AddDebug();


            return builder.Build();
        }
    }
}
