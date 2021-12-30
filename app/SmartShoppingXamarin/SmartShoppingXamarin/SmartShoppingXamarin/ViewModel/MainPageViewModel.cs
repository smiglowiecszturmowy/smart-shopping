using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SmartShoppingXamarin.Annotations;
using SmartShoppingXamarin.Model;
using SmartShoppingXamarin.Services.HomeIngredients;
using SmartShoppingXamarin.View;
using Xamarin.Forms;

namespace SmartShoppingXamarin.ViewModel
{
	public sealed class MainPageViewModel : INotifyPropertyChanged
	{
		private readonly IHomeIngredientsService _homeIngredientsService;
		private readonly Lazy<INavigation> _navigation;

		private ObservableCollection<HomeIngredient> _homeIngredients;

		public ObservableCollection<HomeIngredient> HomeIngredients
		{
			get => _homeIngredients;
			set
			{
				if (Equals(value, _homeIngredients)) return;
				_homeIngredients = value;
				OnPropertyChanged();
			}
		}

		public async Task RefreshList()
		{
			HomeIngredients = new ObservableCollection<HomeIngredient>(await _homeIngredientsService.FindAll());
		}

		public MainPageViewModel(IHomeIngredientsService homeIngredientsService, Lazy<INavigation> navigation)
		{
			_homeIngredientsService = homeIngredientsService;
			_navigation = navigation;
			AddCommand = new Command(OnAddProduct);
		}

		private async void OnAddProduct()
		{
			await _navigation.Value.PushAsync(new AddProductView());
		}

		public Command AddCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}