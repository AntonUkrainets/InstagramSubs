using InstagramSubs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramSubs.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> AddUserAsync(User user);
        Task<User> GetUserByNameAsync(string name);
        Task SaveSessionStateAsync(int userId, string state);
    }
}