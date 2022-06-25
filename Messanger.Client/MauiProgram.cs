using Messanger.Client.ViewModels;
using Messanger.Client.Views;

namespace Messanger.Client
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

            builder.Services.AddSingleton<PreloaderPage>();
            builder.Services.AddSingleton<PreloaderPageViewModel>();


            return builder.Build();
        }
    }
}