using InstagramSubs.LocalAPI.Implements;
using InstagramSubs.LocalAPI.Interfaces;
using InstagramSubs.Data;
using InstagramSubs.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramSubs.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        private static ILocalApi _localApi;
        private static IUserRepository _repository;

        public UserRepository(ILocalApi localApi)
        {
            _localApi = localApi;
        }

        public static IUserRepository GetInstance()
        {
            if(_repository == null)
            {
                _repository = new UserRepository(LocalApi.GetInstance());
                //_localApi.InitUsersList();
            }

            return _repository;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _localApi.GetUsersDataAsync();
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            return _localApi.GetUserByNameAsync(name);
        }

        public Task<int> AddUserAsync(User user)
        {
            return _localApi.AddAsync(user);
        }

        public Task SaveSessionStateAsync(int userId, byte[] state)
        {
            return _localApi.SaveSessionStateAsync(userId, state);
        }
    }
}