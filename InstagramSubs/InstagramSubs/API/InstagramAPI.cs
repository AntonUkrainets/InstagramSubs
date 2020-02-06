using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.SessionHandlers;
using InstagramApiSharp.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace InstagramSubs.API
{
    public class InstagramAPI
    {
        private IInstaApi _instaApi;

        public InstagramAPI()
        {
        }

        private void CreateInstaInstance()
        {
            var userData = CreateUserData();

            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userData)
                .UseLogger(new DebugLogger(LogLevel.All)) //Проходить все уровни аутентификаций
                .SetRequestDelay(RequestDelay.FromSeconds(min: 0, max: 1)) //Промежуток очереди запросов
                .Build();
        }

        public async void CreateConnect()
        {
            CreateInstaInstance();
            LoadSession();

            if (!_instaApi.IsUserAuthenticated)
            {
                var logInResult = await _instaApi.LoginAsync();

                if (logInResult.Succeeded)
                    SaveSession();
                else
                {
                    if (logInResult.Value == InstaLoginResult.ChallengeRequired)
                    {
                        var challenge = await _instaApi.GetChallengeRequireVerifyMethodAsync();
                        if (challenge.Succeeded)
                        {
                            //var topicalExlope = await _instaApi.FeedProcessor.GetTopicalExploreFeedAsync(PaginationParameters.MaxPagesToLoad(1));
                            //var values = topicalExlope.Value;
                        }
                    }
                }
            }
        }

        private UserSessionData CreateUserData()
        {
            var userData = new UserSessionData()
            {
                UserName = "Bobby_Layout",
                Password = "Bobby.Layout",

            };

            return userData;
        }

        private void LoadSession()
        {
            _instaApi?.SessionHandler?.Load();
        }

        private void SaveSession()
        {
            if (_instaApi == null)
                return;

            if (!_instaApi.IsUserAuthenticated)
                return;

            //_instaApi.SessionHandler.Save();
        }
    }
}