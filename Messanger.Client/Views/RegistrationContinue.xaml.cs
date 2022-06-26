using Messanger.Client.ViewModels;

namespace Messanger.Client.Views;

public partial class RegistrationContinue : ContentPage
{
	public RegistrationContinue(RegistrationContinueViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}