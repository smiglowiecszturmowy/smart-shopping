using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SmartShoppingXamarin.Annotations;
using SmartShoppingXamarin.Model;
using SmartShoppingXamarin.Services.HomeIngredients;
using Xamarin.Forms;

namespace SmartShoppingXamarin.ViewModel
{
	public class AddProductViewModel : INotifyPropertyChanged
	{
		private readonly IHomeIngredientsService _homeIngredientsService;

		private bool _productNameEnabled = true;

		public bool ProductNameEnabled
		{
			get => _productNameEnabled;
			set
			{
				if (_productNameEnabled == value)
					return;
				_productNameEnabled = value;
				OnPropertyChanged();
			}
		}

		private bool _productQuantityEnabled = false;

		public bool ProductQuantityEnabled
		{
			get => _productQuantityEnabled;
			set
			{
				if (_productQuantityEnabled == value)
					return;
				_productQuantityEnabled = value;
				OnPropertyChanged();
			}
		}
		
		private bool _productExpirationDateEnabled = false;

		public bool ProductExpirationDateEnabled
		{
			get => _productExpirationDateEnabled;
			set
			{
				if (_productExpirationDateEnabled == value)
					return;
				_productExpirationDateEnabled = value;
				OnPropertyChanged();
			}
		}
		
		public string ProductName { get; set; }
		public string ProductQuantity { get; set; }
		public string ProductVolume { get; set; }
		public DateTime DatePickerMinDate { get; set; }
		public DateTime DatePickerMaxDate { get; set; }
		public DateTime ProductExpirationDate { get; set; }

		public AddProductViewModel(IHomeIngredientsService homeIngredientsService)
		{
			_homeIngredientsService = homeIngredientsService;
			ConfirmNameCommand = new Command(OnConfirmName);
			AddProductCommand = new Command(OnAddProduct);
			ConfirmQuantityCommand = new Command(OnConfirmQuantity);
			Task.Run(async () =>
			{
				await Task.Delay(500);
				OnConfirmName();
				OnConfirmQuantity();
			});
			
			DatePickerMinDate = DateTime.Now;
			DatePickerMaxDate = DateTime.Now.AddDays(30);
			ProductExpirationDate = DateTime.Now;
		}

		private void OnConfirmName()
		{
			ProductQuantityEnabled = true;
			var tabbedPage = (Application.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
			var indexOfCurrentPage = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
			var nextPage = Math.Min(indexOfCurrentPage + 1, tabbedPage.Children.Count - 1);
			tabbedPage.CurrentPage = tabbedPage.Children[nextPage];
		}

		private void OnConfirmQuantity()
		{
			ProductExpirationDateEnabled = true;
			var tabbedPage = (Application.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
			var indexOfCurrentPage = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
			var nextPage = Math.Min(indexOfCurrentPage + 1, tabbedPage.Children.Count - 1);
			tabbedPage.CurrentPage = tabbedPage.Children[nextPage];
		}

		private async void OnAddProduct()
		{
			Console.WriteLine($"Saving entry {ProductName}");
			try
			{
				await _homeIngredientsService.Add(new HomeIngredient {Name = ProductName});
				await Application.Current.MainPage.DisplayAlert("Alert", $"Dodano produkt {ProductName}", "OK");
				Debug.WriteLine("Answer: " + ProductName);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error saving entry {e}");
			}
		}

		public Command ConfirmNameCommand { get; set; }
		public Command ConfirmQuantityCommand { get; set; }
		public Command AddProductCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}