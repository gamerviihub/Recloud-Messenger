using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.ViewModels
{
    public class PreloaderPageViewModel : MvxViewModel
    {
        IConnectivity Connectivity;

        public IMvxCommand LoginPageCommand => new MvxCommand(LoginPage);

        private async void LoginPage()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Упс, на вашем устройстве нет подключения к интернету!", "Закрыть");
                return;
            }
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }


        public PreloaderPageViewModel(IConnectivity connectivity)
        {
            Connectivity = connectivity;
        }
    }
}
