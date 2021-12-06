using System;
using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;

namespace SmartShoppingXamarin.View
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = App.GetViewModel<MainPageViewModel>();
		}
	}
}