using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VideoGameListApp.Models;
using VideoGameListApp.Views;
using Xamarin.Forms;


namespace VideoGameListApp.ViewModels
{
    public class GameListViewModel : INotifyPropertyChanged
    {
        private readonly VideoGameRepository _gameRepository;
        public ObservableCollection<VideoGame> Games { get; set; }
        public ICommand AddCommand { get; } 
        public ICommand DeleteCommand { get; } 

        public GameListViewModel()
        {
            _gameRepository = new VideoGameRepository();
            Games = _gameRepository.GetAllGames();
            AddCommand = new Command(OnAddCommand);
            DeleteCommand = new Command(OnDeleteCommand);
        }

        private void OnDeleteCommand(object obj)
        {
            _gameRepository.DeleteGame(obj as VideoGame);
            Games.Remove(obj as VideoGame);
        }

        private async void OnAddCommand(object obj)
        {
            VideoGame newGame = new VideoGame();
            Games.Add(newGame);
            _gameRepository.SaveOrUpdateGame(newGame);

            GameDetailViewModel viewmodel = new GameDetailViewModel(newGame);
            GameDetailView view= new GameDetailView();
            view.BindingContext = viewmodel;

            await App.Current.MainPage.Navigation.PushAsync(view);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseChangedEvent(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
