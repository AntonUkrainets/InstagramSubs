using InstagramSubs.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InstagramSubs.DataBaseAPI
{
    public class UsersDatabase
    {
        private SQLiteAsyncConnection _database;

        public void Connect()
        {
            var databasePath = GetDatabasePath();

            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<User>().Wait();
        }

        private static string GetDatabasePath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(basePath, "InstaUsers.db3");

            return path;
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            var user = _database
                    .Table<User>()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

            return user;
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            var user = _database
                    .Table<User>()
                    .Where(u => u.Name == name)
                    .FirstOrDefaultAsync();

            return user;
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
                return _database.UpdateAsync(user);
            else
                return _database.InsertAsync(user);
        }

        public Task<int> RemoveUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}