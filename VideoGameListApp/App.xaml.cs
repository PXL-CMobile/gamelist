using System;
using System.IO;
using VideoGameListApp.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    public partial class App : Application
    {
        private static VideoGameDatabase _database;  
        public static VideoGameDatabase Database { 
            get
            {
                if (_database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "VGDB.db3");
                    _database = new VideoGameDatabase(path);
                }
                return _database;
            } 
        }

        public App()
        {
            InitializeComponent();
            /* Wrap the MainPage in a NavigationPage so we can navigate.. */
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
