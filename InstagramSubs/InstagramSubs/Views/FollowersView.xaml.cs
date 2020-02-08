using InstagramSubs.API;
using InstagramSubs.Model;
using Prism.Ioc;
using System.Collections.Generic;
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

            if (string.IsNullOrEmpty(_userContext.User.Name))
            {
                _instagramApi = App.Current.Container.Resolve<InstagramAPI>();

                //await LoadAsync();
            }

            InitProfileFields();
            InitFollowersPricesList();
        }

        private async Task LoadAsync()
        {
            var getCurrentUserResult = await _instagramApi.GetCurrentUserAsync();
            _userContext.User.Name = getCurrentUserResult.Value.UserName;

            var getCurrentUserFollowersResult = await _instagramApi.GetCurrentUserFollowersAsync();
            _userContext.FollowersNumber = getCurrentUserFollowersResult.Value.Count;
        }

        private void InitProfileFields()
        {
            InitImages();

            UserNameLabel.Text = $"{_userContext.User.Name}";
            CountCurrentFollowersLabel.Text = $"{_userContext.FollowersNumber}";
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