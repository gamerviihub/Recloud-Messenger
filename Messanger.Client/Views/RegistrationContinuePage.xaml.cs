using Messanger.Client.ViewModels;

namespace Messanger.Client.Views;

public partial class RegistrationContinuePage : ContentPage
{
	public RegistrationContinuePage(RegistrationContinuePageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}