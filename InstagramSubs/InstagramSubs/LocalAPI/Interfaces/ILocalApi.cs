using InstagramSubs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramSubs.LocalAPI.Interfaces
{
    public interface ILocalApi
    {
        Task<IEnumerable<User>> GetUsersDataAsync();
        Task<User> GetUserByNameAsync(string name);
        Task<int> AddAsync(User user);
        Task SaveSessionStateAsync(int userId, string state);
    }
}