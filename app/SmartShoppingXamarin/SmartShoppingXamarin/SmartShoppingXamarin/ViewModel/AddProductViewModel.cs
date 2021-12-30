using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmartShoppingXamarin.Annotations;

namespace SmartShoppingXamarin.ViewModel
{
	public class AddProductViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}