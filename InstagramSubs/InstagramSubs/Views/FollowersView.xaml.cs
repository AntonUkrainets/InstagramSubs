using InstagramApiSharp.Classes.Models;
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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _userContext = App.Current.Container.Resolve<UserContext>();

            if (string.IsNullOrEmpty((string)_userContext.User.Name))
            {
                _instagramApi = App.Current.Container.Resolve<InstagramAPI>();

                await LoadAsync();
            }

            InitProfileFields();
            InitFollowersPricesList();
        }

        private async Task LoadAsync()
        {
            var getCurrentUserResult = await _instagramApi.GetCurrentUserAsync();
            _userContext.User.Name = getCurrentUserResult.Value.UserName;

            var getCurrentUserFollowersResult = await _instagramApi.GetCurrentUserFollowersAsync();
            _userContext.Followers = getCurrentUserFollowersResult.Value;

            var userFollowingResult = await _instagramApi.GetUserFollowingAsync();
            _userContext.UserFollowing = userFollowingResult.Value;

            GetCountUsersIDontFollowBack(); 
            GetCountUsersDontFollowMe();
        }

        private void GetCountUsersIDontFollowBack()
        {
            var followers = _userContext.Followers;
            var userFollowing = _userContext.UserFollowing;

            _userContext.CountUsersIDontFollowBack = followers.Except(userFollowing).Count();
        }

        private void GetCountUsersDontFollowMe()
        {
            var followers = _userContext.Followers;
            var userFollowing = _userContext.UserFollowing;

            _userContext.CountUsersDontFollowMe = userFollowing.Except(followers).Count();
        }

        private void InitProfileFields()
        {
            InitImages();

            UserNameLabel.Text = $"{_userContext.User.Name}";
            CountCurrentFollowersLabel.Text = $"{_userContext.Followers.Count}";
            CountIDontFollowLabel.Text = $"{_userContext.CountUsersIDontFollowBack}";
            CountDontFollowMeLabel.Text = $"{_userContext.CountUsersDontFollowMe}";
        }

        private void InitImages()
        {
            ProfileImage.Source = _userContext.User.AvatarUri;
            FollowersImage.Source = ImageSource.FromFile("Follower.png");
            CountFollowersImage.Source = ImageSource.FromFile("Follower.png");
        }

        private void InitFollowersPricesList()
        {
            var followerIcon = ImageSource.FromFile("Follower.png");

            FollowersPricesListView.ItemsSource = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "25", Price = "9.99$", Get = "Get", Icon = followerIcon },
                new FollowerPrice { Count = "3", Price = "0.99$", Get = "Get", Icon = followerIcon },
                new FollowerPrice { Count = "12", Price = "4.99$", Get = "Get", Icon = followerIcon },
                new FollowerPrice { Count = "60", Price = "19.99$", Get = "Get", Icon = followerIcon },
                new FollowerPrice { Count = "180", Price = "49.99$", Get = "Get", Icon = followerIcon },
                new FollowerPrice { Count = "400", Price = "99.99$", Get = "Get", Icon = followerIcon }
            };
        }
    }
}