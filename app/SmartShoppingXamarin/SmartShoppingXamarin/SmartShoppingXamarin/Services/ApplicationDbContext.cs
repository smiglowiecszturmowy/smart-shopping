using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SmartShoppingXamarin.Model;
using Xamarin.Forms;

namespace SmartShoppingXamarin.Services
{
	public class ApplicationDbContext : DbContext
	{
		private const string DatabaseName = "sqlite.db";

		public static bool IsMigration = true;

		public DbSet<HomeIngredient> HomeIngredients { get; set; }

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (IsMigration)
				return;

			string databasePath;
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					SQLitePCL.Batteries_V2.Init();
					databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
					break;
				case Device.Android:
					databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
					break;
				default:
					throw new NotImplementedException("Platform not supported");
			}

			optionsBuilder.UseSqlite($"Filename={databasePath}");
		}

		#region Required

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HomeIngredient>(b =>
			{
				b.Property(x => x.Name)
					.IsRequired();
				b.HasKey(x => x.Id);
			});
		}

		#endregion
	}
}