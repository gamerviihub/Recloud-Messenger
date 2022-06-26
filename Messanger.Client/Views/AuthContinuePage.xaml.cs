using Messanger.Client.ViewModels;

namespace Messanger.Client.Views;

public partial class AuthContinuePage : ContentPage
{
	public AuthContinuePage(AuthContinuePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}