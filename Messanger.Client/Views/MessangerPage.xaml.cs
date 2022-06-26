using Messanger.Client.ViewModels;

namespace Messanger.Client.Views;

public partial class MessangerPage : ContentPage
{
	public MessangerPage(MessangerPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}