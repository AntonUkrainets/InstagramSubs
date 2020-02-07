using System.Collections.Generic;

namespace InstagramSubs.LocalAPI.Interfaces
{
    public interface ILocalApi<T>
        where T : class
    {
        IEnumerable<T> GetUsersData();
        void InitUsersList();
        void Add(T user);
        //bool IsAuthorized(T user);
    }
}