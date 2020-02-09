using InstagramSubs.DataBaseAPI;
using InstagramSubs.LocalAPI.Interfaces;
using InstagramSubs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramSubs.LocalAPI.Implements
{
    public class LocalApi : ILocalApi
    {
        private static ILocalApi _localApi;

        private static UsersDatabase _usersDatabase;
        public static UsersDatabase UsersDataBase
        {
            get
            {
                if (_usersDatabase == null)
                {
                    _usersDatabase = new UsersDatabase();
                    _usersDatabase.Connect();
                }

                return _usersDatabase;
            }
        }

        public static ILocalApi GetInstance()
        {
            if (_localApi == null)
            {
                _localApi = new LocalApi();
                _usersDatabase = new UsersDatabase();
                _usersDatabase.Connect();
            }

            return _localApi;
        }

        public async Task<IEnumerable<User>> GetUsersDataAsync()
        {
            return await _usersDatabase.GetUsersAsync();
        }

        public Task<int> AddAsync(User user)
        {
            return _usersDatabase.SaveUserAsync(user);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var tt = await _usersDatabase.GetUsersAsync();

            return await _usersDatabase.GetUserByNameAsync(name);
        }

        public async Task SaveSessionStateAsync(int userId, string state)
        {
            var user = await _usersDatabase.GetUserAsync(userId);

            user.InstagramState = state;

            await _usersDatabase.SaveUserAsync(user);
        }
    }
}