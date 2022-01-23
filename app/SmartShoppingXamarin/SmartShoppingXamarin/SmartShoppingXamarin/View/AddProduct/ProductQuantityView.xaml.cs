using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShoppingXamarin.View.AddProduct
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductQuantityView : ContentPage
	{
		public AddProductViewModel ViewModel { get; }
		public ProductQuantityView()
		{
			InitializeComponent();
			ViewModel = App.GetViewModel<AddProductViewModel>();
		}
	}
}