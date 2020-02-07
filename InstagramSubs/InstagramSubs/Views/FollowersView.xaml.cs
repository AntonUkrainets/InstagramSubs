using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramSubs.API;
using InstagramSubs.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FollowersView : ContentPage
    {
        private ICollection<FollowerPrice> _followersPrices;
        private InstagramAPI _instagramApi;

        private InstaCurrentUser _currentUser;
        private InstaUserShortList _followers;

        public FollowersView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _instagramApi = new InstagramAPI("Bobby_Layout", "Bobby.Layout");

            await LoadAsync();

            InitProfileFields();

            InitFollowersPricesListView();
        }

        private async Task LoadAsync()
        {
            var getCurrentUserResult = await _instagramApi.GetCurrentUserAsync();

            _currentUser = getCurrentUserResult.Value;

            var getCurrentUserFollowersResult = await _instagramApi.GetCurrentUserFollowersAsync();

            _followers = getCurrentUserFollowersResult.Value;
        }

        private void InitProfileFields()
        {
            InitImages();

            UserNameLabel.Text = $"{_currentUser.UserName}";
            CountCurrentFollowersLabel.Text = $"{_followers.Count}";
        }

        private void InitImages()
        {
            ProfileImage.Source = _currentUser.ProfilePicture;
            FollowersImage.Source = ImageSource.FromFile("FollowerIcon.jpg");
            CountFollowersImage.Source = ImageSource.FromFile("FollowerIcon.jpg");
        }

        private void InitFollowersPricesListView()
        {
            var followerIcon = ImageSource.FromFile("FollowerIcon.jpg");

            _followersPrices = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "25", Price = "9.99$", Get = "Get", Icon =  followerIcon },
                new FollowerPrice { Count = "3", Price = "0.99$", Get = "Get", Icon =  followerIcon },
                new FollowerPrice { Count = "12", Price = "4.99$", Get = "Get", Icon =  followerIcon },
                new FollowerPrice { Count = "60", Price = "19.99$", Get = "Get", Icon =  followerIcon },
                new FollowerPrice { Count = "180", Price = "49.99$", Get = "Get", Icon =  followerIcon },
                new FollowerPrice { Count = "400", Price = "99.99$", Get = "Get", Icon =  followerIcon }
            };

            FollowersPricesListView.ItemsSource = _followersPrices;
        }
    }
}