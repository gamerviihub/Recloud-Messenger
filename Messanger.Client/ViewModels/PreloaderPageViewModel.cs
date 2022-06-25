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
        public IMvxCommand LoginPageCommand => new MvxCommand(LoginPage);

        private void LoginPage()
        {

        }

        public PreloaderPageViewModel()
        {

        }
    }
}
