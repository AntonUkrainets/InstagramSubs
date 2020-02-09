using InstagramSubs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramSubs.LocalAPI.Interfaces
{
    public interface ILocalApi
    {
        Task<IEnumerable<User>> GetUsersDataAsync();
        //void InitUsersList();
        Task<User> GetUserByNameAsync(string name);
        Task<int> AddAsync(User user);
        Task SaveSessionStateAsync(int userId, byte[] state);
        //bool IsAuthorized(T user);
    }
}