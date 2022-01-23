using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShoppingXamarin.View.AddProduct
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductNameView : ContentPage
	{
		public AddProductViewModel ViewModel { get; }
		
		public ProductNameView()
		{
			InitializeComponent();
			ViewModel = App.GetViewModel<AddProductViewModel>();
		}
	}
}