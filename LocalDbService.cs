using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryManager
{
    public class LocalDbService
    {
        private const string DB_NAME = "MusicInfo.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Music>();
        }

        public async Task<List<Music>> GetSongs()
        {
            return await _connection.Table<Music>().ToListAsync();
        }

        public async Task<Music> GetById(int id)
        {
            return await _connection.Table<Music>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task Create(Music music)
        {
            await _connection.InsertAsync(music);
        }

        public async Task Update(Music music)
        {
            await _connection.UpdateAsync(music);
        }

        public async Task Delete(Music music)
        {
            await _connection.DeleteAsync(music);
        }


    }
}
