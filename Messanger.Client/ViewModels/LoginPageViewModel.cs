using Messanger.Client.Services.API;
using Messanger.Client.Views;
using Messanger.Server.DataBase.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.ViewModels
{
    public class LoginPageViewModel : MvxViewModel
    {

        #region Переменные

        private Models.Config Config;

        #region Логин пользователя
        private string _Login = String.Empty;
        public string Login
        {
            get { return _Login; }
            set { SetProperty(ref _Login, value); }
        }
        #endregion

        #endregion

        #region Команды
        #region Авторизация
        public IMvxCommand CheckAccountCommand => new MvxCommand(CheckAccount);

        private async void CheckAccount()
        {
            if (String.IsNullOrEmpty(Login))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Укажите логин учетной записи", "Ок");
                return;
            }

            User user = await UserApi.GetUserInfo(Login, Config);

            if (user.IsRegisteredEnded)
            {
                await Shell.Current.GoToAsync(nameof(AuthContinuePage),
                    new Dictionary<string, object> {
                        { "User", user },
                        { "Config", Config }
                    }
                );
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(RegistrationContinuePage),
                    new Dictionary<string, object> {
                        { "User", user },
                        { "Config", Config }
                    }
                );
            }


        }
        #endregion
        #endregion

        public LoginPageViewModel(Models.Config config)
        {
            Config = config;
        }
    }
}
