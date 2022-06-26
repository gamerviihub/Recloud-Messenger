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
    public class RegistrationContinuePageViewModel : MvxViewModel
    {
        #region Переменные

        #region Логин пользователя
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
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
        #region Пароль пользователя
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion
        #region Пароль пользователя (Подтверждение)
        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { SetProperty(ref _ConfirmPassword, value); }
        }
        #endregion

        #endregion

        #region Команды
        #region Авторизация
        public IMvxCommand ContinueRegistrationCommand => new MvxCommand(ContinueRegistration);

        private async void ContinueRegistration()
        {
            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(ConfirmPassword))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Заполните все поля, для продолжения регистрации!", "Ок");
                return;
            }

            if (Password.Equals(ConfirmPassword) == false)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Введенные пароли не совпадают, проверьте регистр и язык ввода!", "Ок");
                return;
            }

            // ToDo: Сделать хеширование пароля
            User.Password = Password;

            var newUser = await UserApi.UpdateUser(User.Id, User, Config);

            await Shell.Current.GoToAsync(nameof(MessangerPage),
                new Dictionary<string, object>
                {
                    { "User", User },
                    { "Config", Config },
                }
            );


        }
        #endregion
        #endregion

        public RegistrationContinuePageViewModel()
        {

        }
    }
}
