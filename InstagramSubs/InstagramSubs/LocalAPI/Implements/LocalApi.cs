using InstagramSubs.DataBaseAPI;
using InstagramSubs.LocalAPI.Interfaces;
using InstagramSubs.Model;
using System.Collections.Generic;

namespace InstagramSubs.LocalAPI.Implements
{
    public class LocalApi : ILocalApi<InstaUser>
    {
        private static ILocalApi<InstaUser> _localApi;

        private static UsersDataBase _usersDataBase;
        public static UsersDataBase UsersDataBase
        {
            get
            {
                if (_usersDataBase == null)
                    _usersDataBase = new UsersDataBase();

                return _usersDataBase;
            }
        }

        public static ILocalApi<InstaUser> GetInstance()
        {
            if (_localApi == null)
            {
                _localApi = new LocalApi();
                _usersDataBase = new UsersDataBase();
            }

            return _localApi;
        }

        public void InitUsersList()
        {
            var user = new InstaUser { Name = "Bobby_Layout", Password = "Bobby.Layout" };
            _usersDataBase.SaveUserAsync(user);
        }

        public IEnumerable<InstaUser> GetUsersData()
        {
            return _usersDataBase.GetUsersAsync().Result;
        }

        public void Add(InstaUser user)
        {
            _usersDataBase.SaveUserAsync(user);
        }
    }
}