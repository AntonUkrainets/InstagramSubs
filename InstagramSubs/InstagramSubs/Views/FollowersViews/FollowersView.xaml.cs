using InstagramSubs.API;
using InstagramSubs.Model;
using Prism.Ioc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FollowersView : ContentPage
    {
        private InstagramAPI _instagramApi;
        private UserContext _userContext;

        public FollowersView()
        {
            InitializeComponent();

            InitFollowersPricesList();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _userContext = App.Current.Container.Resolve<UserContext>();

            if (string.IsNullOrEmpty(_userContext.User.Name))
            {
                _instagramApi = App.Current.Container.Resolve<InstagramAPI>();

                await LoadAsync();
            }

            InitProfileFields();
        }

        private async Task LoadAsync()
        {
            var getCurrentUserResult = await _instagramApi.GetCurrentUserAsync();
            _userContext.User.Name = getCurrentUserResult.Value.UserName;

            var getCurrentUserFollowersResult = await _instagramApi.GetCurrentUserFollowersAsync();
            _userContext.Followers = getCurrentUserFollowersResult.Value;

            var userFollowingResult = await _instagramApi.GetUserFollowingAsync();
            _userContext.UserFollowing = userFollowingResult.Value;

            GetUsersCountIDontFollow();
            GetUsersCountDontFollowMe();
        }

        private void GetUsersCountIDontFollow()
        {
            var followers = _userContext.Followers;
            var userFollowing = _userContext.UserFollowing;

            _userContext.Followers = followers.Except(userFollowing).ToArray();

            _userContext.CountUsersIDontFollowBack = followers.Except(userFollowing).Count();
        }

        private void GetUsersCountDontFollowMe()
        {
            var followers = _userContext.Followers;
            var userFollowing = _userContext.UserFollowing;

            _userContext.CountUsersDontFollowMe = userFollowing.Except(followers).Count();
        }

        private void InitProfileFields()
        {
            ProfileImage.Source = _userContext.User.AvatarUri;
            UserNameLabel.Text = $"{_userContext.User.Name}";
            CountCurrentFollowersLabel.Text = $"{_userContext.Followers.Count}";
            CountIDontFollowLabel.Text = $"{_userContext.CountUsersIDontFollowBack}";
            CountDontFollowMeLabel.Text = $"{_userContext.CountUsersDontFollowMe}";
        }

        private void InitFollowersPricesList()
        {
            FollowersPricesListView.ItemsSource = new List<Price>
            {
                new Price { CountFollowers = "25", Cost = "9.99$" },
                new Price { CountFollowers = "3", Cost = "0.99$" },
                new Price { CountFollowers = "12", Cost = "4.99$" },
                new Price { CountFollowers = "60", Cost = "19.99$" },
                new Price { CountFollowers = "180", Cost = "49.99$" },
                new Price { CountFollowers = "400", Cost = "99.99$" }
            };
        }
    }
}