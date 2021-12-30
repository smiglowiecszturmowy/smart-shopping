using System.Collections.Generic;
using System.Threading.Tasks;
using SmartShoppingXamarin.Model;

namespace SmartShoppingXamarin.Services.HomeIngredients
{
	public interface IHomeIngredientsService
	{
		Task<List<HomeIngredient>> FindAll();
		Task                       Add(HomeIngredient homeIngredient);
	}
}