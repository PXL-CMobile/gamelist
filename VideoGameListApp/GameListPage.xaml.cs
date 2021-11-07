using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentPage
    {
        /*private ObservableCollection<VideoGame> listInCSharp = new ObservableCollection<VideoGame>
        {
            new VideoGame {Title="GTA5", Genre="Action", Rating=95, ReleaseDate=new DateTime(2013,01,01), CoverPictureURL="https://gamegasm.files.wordpress.com/2013/04/actual_1364906194.jpg"},
            new VideoGame {Title="Fortnite", Genre="Shooter", Rating=8, ReleaseDate=new DateTime(2017,01,01), CoverPictureURL="https://www.gamevideos.nl/storage/1491/fortnite.jpg"},
            new VideoGame {Title="Skyrim", Genre="RPG", Rating=65, ReleaseDate=new DateTime(2011,01,01), CoverPictureURL="https://res.cloudinary.com/www-fun-be/image/fetch/q_auto,f_auto/https://media.fun.be/media/catalog/product/cache/43/image/768x/9df78eab33525d08d6e5fb8d27136e95/2/0/20421455.jpg"}
        };*/

        public GameListPage()
        {
            InitializeComponent();

            /* Bind the List to the ListView (xaml) */
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            GameListElement.ItemsSource = await App.Database.GetVideoGamesAsync();
        }

        private async void VideoGameTapped(object sender, ItemTappedEventArgs e)
        {
            VideoGame selectedGame = e.Item as VideoGame;
            /* // Or do:
             * VideoGame selectedGame = (VideoGame) e.Item; 
             */
            await this.Navigation.PushAsync(new GameDetailPage(selectedGame));
            ((ListView)sender).SelectedItem = null;

        }

        private async void AddANewGame(object sender, EventArgs e)
        {
            VideoGame newGame = new VideoGame();
            string title = await DisplayPromptAsync("Wat is de titel?", "");
            string genre = await DisplayPromptAsync("Wat is het genre?", "");

            newGame.Title = title;
            newGame.Genre = genre;
            newGame.CoverPictureURL = null;

            //listInCSharp.Add(newGame);
            await App.Database.SaveVideoGameAsync(newGame);
            GameListElement.ItemsSource = await App.Database.GetVideoGamesAsync();
        }

        private async void RemoveThisGame(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            //listInCSharp.Remove(button.CommandParameter as VideoGame);

            await App.Database.DeleteVideoGameAsync(button.CommandParameter as VideoGame);
            GameListElement.ItemsSource = await App.Database.GetVideoGamesAsync();
        }
    }
}