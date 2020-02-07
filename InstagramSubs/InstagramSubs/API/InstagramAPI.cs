using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using System.Threading.Tasks;

namespace InstagramSubs.API
{
    public class InstagramAPI
    {
        private IInstaApi _instaApi;

        public InstagramAPI(string userName, string password)
        {
            var userSessionData = new UserSessionData
            {
                UserName = userName,
                Password = password
            };

            _instaApi = CreateInstaInstance(userSessionData);
        }

        private IInstaApi CreateInstaInstance(UserSessionData userSessionData)
        {
            return InstaApiBuilder.CreateBuilder()
                .SetUser(userSessionData)
                .UseLogger(new DebugLogger(LogLevel.All)) //Проходить все уровни аутентификаций
                .SetRequestDelay(RequestDelay.FromSeconds(min: 0, max: 1)) //Промежуток очереди запросов
                .Build();
        }

        private async Task LoginAsync()
        {
            _instaApi.SessionHandler?.Load();

            await _instaApi.LoginAsync();

            if (!_instaApi.IsUserAuthenticated)
                return;

            _instaApi.SessionHandler?.Save();
        }

        public async Task<IResult<InstaCurrentUser>> GetCurrentUserAsync()
        {
            if (!_instaApi.IsUserAuthenticated)
                await LoginAsync();

            return await _instaApi.UserProcessor.GetCurrentUserAsync();
        }

        public async Task<IResult<InstaUserShortList>> GetCurrentUserFollowersAsync()
        {
            if (!_instaApi.IsUserAuthenticated)
                await LoginAsync();

            return await _instaApi.UserProcessor.GetCurrentUserFollowersAsync(PaginationParameters.Empty);
        }
    }
}