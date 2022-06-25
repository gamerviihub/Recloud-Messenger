﻿using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.ViewModels
{
    public class LoginPageViewModel : MvxViewModel
    {

        #region Переменные

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



        }
        #endregion
        #endregion

        public LoginPageViewModel()
        {

        }
    }
}