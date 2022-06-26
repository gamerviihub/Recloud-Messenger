using Messanger.Client.Services.API;
using Messanger.Client.Views;
using Messanger.Server.DataBase.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.ViewModels
{
    [QueryProperty("User", "User")]
    [QueryProperty("Config", "Config")]
    public class AuthContinuePageViewModel : MvxViewModel
    {
        #region Переменные
        #region Объект пользователя
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion
        #region Пароль пользователя
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion 
        #region Конфиг
        private Models.Config _Config;
        public Models.Config Config
        {
            get { return _Config; }
            set { SetProperty(ref _Config, value); }
        }
        #endregion
        #endregion

        #region Команды
        #region Авторизация
        public IMvxCommand ContinueAuthCommand => new MvxCommand(ContinueAuth);

        private async void ContinueAuth()
        {
            if (String.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
                return;
            }

            var checkUser = await UserApi.GetUserInfo(User.Login, Config);

            // ToDo: Сделать хеширование пароля
            if (checkUser.Password.Equals(Password) == false)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Введен неверный пароль!", "Ок");
                return;
            }

            await Shell.Current.GoToAsync(nameof(MessangerPage),
                new Dictionary<string, object>
                {
                    { "User", checkUser },
                    { "Config", Config }
                }
            );


        }
        #endregion
        #endregion

        public AuthContinuePageViewModel()
        {

        }

    }
}
