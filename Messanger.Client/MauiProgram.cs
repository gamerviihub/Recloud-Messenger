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

            Models.Config config = Models.Config.LoadConfig().Result;

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            builder.Services.AddSingleton<PreloaderPage>();
            builder.Services.AddSingleton<Models.Config>(config);

            builder.Services.AddSingleton<PreloaderPageViewModel>();

            builder.Services.AddSingleton<RegistrationContinuePage>();
            builder.Services.AddSingleton<RegistrationContinuePageViewModel>();

            builder.Services.AddTransient<MessangerPage>();
            builder.Services.AddTransient<MessangerPageViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();

            builder.Services.AddTransient<AuthContinuePage>();
            builder.Services.AddTransient<AuthContinuePageViewModel>();


            return builder.Build();
        }
    }
}