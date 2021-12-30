using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartShoppingXamarin.Model;

namespace SmartShoppingXamarin.Services.HomeIngredients
{
	public class HomeIngredientsDatabaseService : IHomeIngredientsService
	{
		private readonly ApplicationDbContext _dbContext;

		public HomeIngredientsDatabaseService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<HomeIngredient>> FindAll()
		{
			return await _dbContext.HomeIngredients.ToListAsync();
		}

		public async Task Add(HomeIngredient homeIngredient)
		{
			await _dbContext.HomeIngredients.AddAsync(homeIngredient);
			await _dbContext.SaveChangesAsync();
		}
	}
}