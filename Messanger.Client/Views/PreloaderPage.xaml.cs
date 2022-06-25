using Messanger.Client.ViewModels;
using MvvmCross.ViewModels;

namespace Messanger.Client.Views;

public partial class PreloaderPage : ContentPage
{
	public PreloaderPage(PreloaderPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}