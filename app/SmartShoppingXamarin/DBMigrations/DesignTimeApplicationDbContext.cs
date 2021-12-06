using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SmartShoppingXamarin.Services;

namespace DBMigrations
{
	public class DesignTimeApplicationDbContext : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var dbContextBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			dbContextBuilder.UseSqlite("Filename=sqlite.db");

			return new ApplicationDbContext(dbContextBuilder.Options);
		}
	}
}