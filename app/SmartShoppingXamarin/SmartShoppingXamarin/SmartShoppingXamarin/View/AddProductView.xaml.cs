using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShoppingXamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProductView : ContentPage
	{
		public AddProductViewModel ViewModel { get; }
		
		public AddProductView()
		{
			InitializeComponent();

			ViewModel = App.GetViewModel<AddProductViewModel>();
		}
	}
}