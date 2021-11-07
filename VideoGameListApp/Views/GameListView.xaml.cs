using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using VideoGameListApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListView : ContentPage
    {
        public GameListView()
        {
            InitializeComponent();
        }

        private async void VideoGameTapped(object sender, ItemTappedEventArgs e)
        {
            VideoGame selectedGame = e.Item as VideoGame;
            /* // Or do:
             * VideoGame selectedGame = (VideoGame) e.Item; 
             */
            GameDetailViewModel viewmodel = new GameDetailViewModel(selectedGame);
            GameDetailView page = new GameDetailView();
            page.BindingContext = viewmodel;

            await this.Navigation.PushAsync(page);
            ((ListView)sender).SelectedItem = null;

        }

    }
}