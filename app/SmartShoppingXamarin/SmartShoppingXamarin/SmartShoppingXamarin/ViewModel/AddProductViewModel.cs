using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SmartShoppingXamarin.Annotations;
using SmartShoppingXamarin.Model;
using SmartShoppingXamarin.Services.HomeIngredients;
using Xamarin.Forms;

namespace SmartShoppingXamarin.ViewModel
{
	public class AddProductViewModel : INotifyPropertyChanged
	{
		private readonly IHomeIngredientsService _homeIngredientsService;

		public AddProductViewModel(IHomeIngredientsService homeIngredientsService)
		{
			_homeIngredientsService = homeIngredientsService;
			AddCommand = new Command<object>(OnNew);
		}
		
		private async void OnNew(object obj)
		{
			Console.WriteLine($"Saving entry {obj}");
			try
			{
				var entry = (Entry)obj;
				await _homeIngredientsService.Add(new HomeIngredient { Name = entry.Text });
				await Application.Current.MainPage.DisplayAlert ("Alert", $"Dodano produkt {entry.Text}", "OK");
				Debug.WriteLine ("Answer: " + entry.Text);
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