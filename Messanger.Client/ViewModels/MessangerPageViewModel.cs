using Messanger.Server.DataBase.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.ViewModels
{
    [QueryProperty("User", "User")]
    public class MessangerPageViewModel : MvxViewModel
    {
        #region Логин пользователя
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        public MessangerPageViewModel()
        {

        }
    }
}
