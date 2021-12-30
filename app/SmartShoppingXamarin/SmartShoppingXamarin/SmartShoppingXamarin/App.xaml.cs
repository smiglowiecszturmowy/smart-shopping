using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartShoppingXamarin.Model;
using SmartShoppingXamarin.Services;
using SmartShoppingXamarin.Services.HomeIngredients;
using SmartShoppingXamarin.View;
using SmartShoppingXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace SmartShoppingXamarin
{
	public partial class App : Application
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public App()
		{
			InitializeComponent();

			SetupServices();
			MigrateDb();

			MainPage = new NavigationPage(new MainPage());
		}

		private void SetupServices()
		{
			var services = new ServiceCollection();
			
			ApplicationDbContext.IsMigration = false;
			services.AddDbContext<ApplicationDbContext>();
			services.AddSingleton<IHomeIngredientsService, HomeIngredientsDatabaseService>();
			services.AddSingleton(new Lazy<INavigation>(() => MainPage.Navigation));

			services.AddSingleton<MainPageViewModel>();
			services.AddSingleton<AddProductViewModel>();

			ServiceProvider = services.BuildServiceProvider();
		}

		private static void MigrateDb()
		{
			var appDbContext = ServiceProviderServiceExtensions.GetService<ApplicationDbContext>(ServiceProvider);
			appDbContext.Database.Migrate();
			appDbContext.Database.EnsureCreated();

			if (appDbContext.HomeIngredients.ToList().Count == 0)
			{
				for (var i = 0; i < 20; i++)
				{
					appDbContext.HomeIngredients.Add(new HomeIngredient
					{
						Name = $"Skladnik {i}"
					});
				}

				appDbContext.SaveChanges();
			}
		}

		public static TViewModel GetViewModel<TViewModel>() where TViewModel : class =>
			ServiceProviderServiceExtensions.GetService<TViewModel>(ServiceProvider);

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}