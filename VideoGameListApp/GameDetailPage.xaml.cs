using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetailPage : ContentPage
    {
        private VideoGame _game;

        public GameDetailPage(VideoGame selectedGame)
        {
            InitializeComponent();
            _game = selectedGame;
            this.BindingContext = selectedGame;

            PictureButton.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");

                _game.CoverPictureURL = file.Path;
                //image.Source = ImageSource.FromStream(() =>
                //{
                //    var stream = file.GetStream();
                //    return stream;
                //});
            };

        }

        private void TimeForDebug(object sender, EventArgs e)
        {
            /* change the properties of our game-object here and investigate the 
             changes in the objects AND the UI-elements */
        }

        private async void SaveGame(object sender, EventArgs e)
        {
            await App.Database.SaveVideoGameAsync(_game);
        }
    }
}