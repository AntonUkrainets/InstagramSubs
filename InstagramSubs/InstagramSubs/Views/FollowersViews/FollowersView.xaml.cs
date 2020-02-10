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
            InitImages();
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

        private void InitImages()
        {
            FollowersImage.Source = ImageSource.FromFile("Follower.png");
            CountFollowersImage.Source = ImageSource.FromFile("Follower.png");
        }

        private void InitFollowersPricesList()
        {
            FollowersPricesListView.ItemsSource = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "25", Price = "9.99$" },
                new FollowerPrice { Count = "3", Price = "0.99$" },
                new FollowerPrice { Count = "12", Price = "4.99$" },
                new FollowerPrice { Count = "60", Price = "19.99$" },
                new FollowerPrice { Count = "180", Price = "49.99$" },
                new FollowerPrice { Count = "400", Price = "99.99$" }
            };
        }
    }
}