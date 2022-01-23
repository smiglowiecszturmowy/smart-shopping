using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShoppingXamarin.View.AddProduct
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductExpirationDate : ContentPage
	{
		public AddProductViewModel ViewModel { get; }

		public ProductExpirationDate()
		{
			InitializeComponent();
			ViewModel = App.GetViewModel<AddProductViewModel>();
		}
	}
}