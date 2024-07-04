using MBaqueroPTres.Repositories;
using Microsoft.Extensions.Logging;

namespace MBaqueroPTres
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            string dbPath = FileAccessHelper.GetLocalFilePath("BRBA.DB");
            builder.Services.AddSingleton<BreakingBadRepo>(s => ActivatorUtilities.CreateInstance<BreakingBadRepo>(s, dbPath));
            return builder.Build();
        }
    }
}
