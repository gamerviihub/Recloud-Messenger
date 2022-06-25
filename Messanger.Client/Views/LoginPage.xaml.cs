using Messanger.Client.ViewModels;

namespace Messanger.Client.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}