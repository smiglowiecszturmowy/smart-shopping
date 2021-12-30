using System;
using System.IO;
using Windows.Storage;

namespace SmartShoppingXamarin.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Services.ApplicationDbContext.DbPath = filename =>
            {
                ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();
                return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            };
            LoadApplication(new SmartShoppingXamarin.App());
        }
    }
}
