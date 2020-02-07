using System.Collections.Generic;

namespace InstagramSubs.Repository.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        void AddUser(T user);
    }
}