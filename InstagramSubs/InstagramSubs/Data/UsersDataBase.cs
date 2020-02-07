using InstagramSubs.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InstagramSubs.DataBaseAPI
{
    public class UsersDataBase
    {
        private readonly SQLiteAsyncConnection _database;
        private readonly string _databasePath;

        public UsersDataBase()
        {
            _databasePath = GetDatabasePath();

            _database = new SQLiteAsyncConnection(_databasePath);
            _database.CreateTableAsync<InstaUser>().Wait();
        }

        private static string GetDatabasePath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(basePath, "InstaUsers.db3");

            return path;
        }

        public Task<List<InstaUser>> GetUsersAsync()
        {
            return _database.Table<InstaUser>().ToListAsync();
        }

        public Task<InstaUser> GetUserAsync(int id)
        {
            var user = _database
                    .Table<InstaUser>()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

            return user;
        }

        public Task<int> SaveUserAsync(InstaUser user)
        {
            if (user.Id != 0)
                return _database.UpdateAsync(user);
            else
                return _database.InsertAsync(user);
        }

        public Task<int> RemoveUserAsync(InstaUser user)
        {
            return _database.DeleteAsync(user);
        }
    }
}