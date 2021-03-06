﻿using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using InstagramSubs.Data;
using InstagramSubs.Repository.Interfaces;
using System.Threading.Tasks;

namespace InstagramSubs.API
{
    public class InstagramAPI
    {
        private IInstaApi _instaApi;
        private IUserRepository _repository;
        private string _userName;

        public InstagramAPI(string userName, string password)
        {
            _userName = userName;

            var userSessionData = new UserSessionData
            {
                UserName = userName,
                Password = password
            };

            _instaApi = CreateInstaInstance(userSessionData);

            _repository = Repository.Implements.UserRepository.GetInstance();
        }

        private async Task RestoreUserSession(string userName)
        {
            var user = await _repository.GetUserByNameAsync(userName);

            if (user?.InstagramState == null)
                return;

            await _instaApi.LoadStateDataFromStringAsync(user.InstagramState);
        }

        private async Task SaveSessionStateAsync()
        {
            var stateData = _instaApi.GetStateDataAsString();

            var user = await _repository.GetUserByNameAsync(_userName);

            int userId;

            if (user == null)
            {
                var newUser = new User();
                newUser.Name = _userName;

                userId = await _repository.AddUserAsync(newUser);
            }
            else
            {
                userId = user.Id;
            }

            await _repository.SaveSessionStateAsync(userId, stateData);
        }

        private IInstaApi CreateInstaInstance(UserSessionData userSessionData)
        {
            return InstaApiBuilder.CreateBuilder()
                .SetUser(userSessionData)
                .UseLogger(new DebugLogger(LogLevel.All))
                .SetRequestDelay(RequestDelay.FromSeconds(min: 0, max: 1))
                .Build();
        }

        private async Task LoginAsync()
        {
            await RestoreUserSession(_userName);

            if (_instaApi.IsUserAuthenticated)
                return;

            _instaApi.SessionHandler?.Load();

            await _instaApi.LoginAsync();

            if (!_instaApi.IsUserAuthenticated)
                return;

            await SaveSessionStateAsync();

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

        public async Task<IResult<InstaUserShortList>> GetUserFollowingAsync()
        {
            if (!_instaApi.IsUserAuthenticated)
                await LoginAsync();

            return await _instaApi.UserProcessor.GetUserFollowingAsync(_userName, PaginationParameters.Empty);
        }
    }
}