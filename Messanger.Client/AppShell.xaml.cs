using Messanger.Client.Views;

namespace Messanger.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegistrationContinuePage), typeof(RegistrationContinuePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MessangerPage), typeof(MessangerPage));
            Routing.RegisterRoute(nameof(AuthContinuePage), typeof(AuthContinuePage));
        }
    }
}