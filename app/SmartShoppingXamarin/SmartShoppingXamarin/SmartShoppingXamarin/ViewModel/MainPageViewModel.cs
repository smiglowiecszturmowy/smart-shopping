using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SmartShoppingXamarin.Annotations;
using SmartShoppingXamarin.Model;
using SmartShoppingXamarin.Services.HomeIngredients;
using Xamarin.Forms;

namespace SmartShoppingXamarin.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private readonly IHomeIngredientsService _homeIngredientsService;

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

		public MainPageViewModel(IHomeIngredientsService homeIngredientsService)
		{
			_homeIngredientsService = homeIngredientsService;

			Task.Run(async () => HomeIngredients = new ObservableCollection<HomeIngredient>(await _homeIngredientsService.FindAll()));

			AddCommand = new Command<object>(OnNew);
		}

		private async void OnNew(object obj)
		{
			Console.WriteLine($"Saving entry {obj}");
			try
			{
				var entry = (Entry)obj;
				await _homeIngredientsService.Add(new HomeIngredient { Name = entry.Text });
				HomeIngredients = new ObservableCollection<HomeIngredient>(await _homeIngredientsService.FindAll());
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error saving entry {e}");
			}
		}

		public Command<object> AddCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}