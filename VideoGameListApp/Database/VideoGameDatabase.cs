using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;

namespace VideoGameListApp.Database
{
    public class VideoGameDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public VideoGameDatabase(string pathToDB) 
        {
            _database = new SQLiteAsyncConnection(pathToDB);
            _database.CreateTableAsync<VideoGame>();
        }

        public Task<List<VideoGame>> GetVideoGamesAsync()
        {
            return _database.Table<VideoGame>().ToListAsync();
        }

        public Task<int> SaveVideoGameAsync(VideoGame gameToSave)
        {
            if (gameToSave.ID != 0)
            {
                return _database.UpdateAsync(gameToSave);
            }
            else
            {
                return _database.InsertAsync(gameToSave);
            }
        }

        public Task<int> DeleteVideoGameAsync(VideoGame gameToDelete)
        {
            return _database.DeleteAsync(gameToDelete);
        }
    }

}
