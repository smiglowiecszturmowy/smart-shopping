using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;

namespace SmartShoppingXamarin.View
{
	public partial class MainPage : ContentPage
	{
		public MainPageViewModel ViewModel { get; }
		
		public MainPage()
		{
			InitializeComponent();

			ViewModel = App.GetViewModel<MainPageViewModel>();
		}

		protected override void OnAppearing()
		{
			_ = ViewModel.RefreshList();
		}
	}
}