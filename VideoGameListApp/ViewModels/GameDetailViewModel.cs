using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VideoGameListApp.Models;
using Xamarin.Forms;

namespace VideoGameListApp.ViewModels
{
    public class GameDetailViewModel : INotifyPropertyChanged
    {
        private VideoGameRepository _videoGameRepository;
        private VideoGame _selectedGame;

        public ICommand SaveCommand { get; }
        public ICommand AddPictureCommand { get; }

        public GameDetailViewModel(VideoGame game)
        {
            _videoGameRepository = new VideoGameRepository();
            Game = game;
            SaveCommand = new Command(OnSaveCommand);
            AddPictureCommand = new Command(OnAddPicture);
        }

        private void OnSaveCommand()
        {
            _videoGameRepository.SaveOrUpdateGame(Game);
        }


        public VideoGame Game
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                RaiseChangedEvent(nameof(Game));
            }
        }

        private async void OnAddPicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

            Game.CoverPictureURL = file.Path;
            _selectedGame.RaiseChangedEvent(nameof(Game.CoverPictureURL));
            _videoGameRepository.SaveOrUpdateGame(Game);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseChangedEvent(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
