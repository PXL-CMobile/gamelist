using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VideoGameListApp.Models
{
    class VideoGameRepository
    {
        public ObservableCollection<VideoGame> GetAllGames()
        {
            return new ObservableCollection<VideoGame>(App.Database.GetVideoGamesAsync().Result);
        }

        public async void SaveOrUpdateGame(VideoGame newGame)
        {
            await App.Database.SaveVideoGameAsync(newGame);
        }

        public async void DeleteGame(VideoGame videoGame)
        {
            await App.Database.DeleteVideoGameAsync(videoGame);
        }
    }
}
