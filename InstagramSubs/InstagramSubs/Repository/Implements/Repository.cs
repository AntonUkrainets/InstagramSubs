using InstagramSubs.LocalAPI.Implements;
using InstagramSubs.LocalAPI.Interfaces;
using InstagramSubs.Model;
using InstagramSubs.Repository.Interfaces;
using System.Collections.Generic;

namespace InstagramSubs.Repository.Implements
{
    public class Repository : IRepository<InstaUser>
    {
        private static ILocalApi<InstaUser> _localApi;
        private static IRepository<InstaUser> _repository;

        public Repository(ILocalApi<InstaUser> localApi)
        {
            _localApi = localApi;
        }

        public static IRepository<InstaUser> GetInstance()
        {
            if(_repository == null)
            {
                _repository = new Repository(LocalApi.GetInstance());
                //_localApi.InitUsersList();
            }

            return _repository;
        }

        public IEnumerable<InstaUser> GetAll()
        {
            return _localApi.GetUsersData();
        }

        public void AddUser(InstaUser user)
        {
            _localApi.Add(user);
        }
    }
}