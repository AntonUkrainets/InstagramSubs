using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using InstagramSubs.Repository.Interfaces;
using System;
using System.Linq;

namespace InstagramSubs.API
{
    public class InstagramAPI
    {
        public IInstaApi InstaApi { get; private set; }

        public InstaCurrentUser _currentUser { get; private set; }
        public int _countFollowers { get; private set; }

        private Action _initProfileFields;

        private readonly IRepository<Model.InstaUser> _repository;

        public InstagramAPI(Action initProfileFields)
        {
            _initProfileFields = initProfileFields;

            _repository = Repository.Implements.Repository.GetInstance();
        }

        private IInstaApi CreateInstaInstance()
        {
            var userData = CreateUserData();

            InstaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userData)
                .UseLogger(new DebugLogger(LogLevel.All)) //Проходить все уровни аутентификаций
                .SetRequestDelay(RequestDelay.FromSeconds(min: 0, max: 1)) //Промежуток очереди запросов
                .Build();

            return InstaApi;
        }

        public async void CreateConnect()
        {
            CreateInstaInstance();
            LoadSession();

            if (!InstaApi.IsUserAuthenticated)
            {
                var logInResult = await InstaApi.LoginAsync();

                if (logInResult.Succeeded)
                {
                    SaveSession();

                    var userTask = await InstaApi.UserProcessor.GetCurrentUserAsync();
                    _currentUser = userTask.Value;

                    var followersTask = await InstaApi.UserProcessor.GetCurrentUserFollowersAsync(PaginationParameters.Empty);
                    _countFollowers = followersTask.Value.Count;

                    _initProfileFields.Invoke();
                }
            }
        }

        private UserSessionData CreateUserData()
        {
            var instaUser = _repository.GetAll().FirstOrDefault();

            var userData = new UserSessionData
            {
                UserName = instaUser.Name,
                Password = instaUser.Password
            };

            return userData;
        }

        private void LoadSession()
        {
            InstaApi?.SessionHandler?.Load();
        }

        private void SaveSession()
        {
            if (InstaApi == null)
                return;

            if (!InstaApi.IsUserAuthenticated)
                return;

            InstaApi?.SessionHandler?.Save();
        }
    }
}