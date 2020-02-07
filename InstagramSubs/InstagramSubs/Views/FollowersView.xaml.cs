using InstagramSubs.API;
using InstagramSubs.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FollowersView : ContentPage
    {
        private ICollection<FollowerPrice> _followersPrices;
        private InstagramAPI _instagramApi;
        private Action _initProfileFields;

        public FollowersView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitImages();
            InitFollowersPricesListView();

            _initProfileFields = new Action(InitProfileFields);

            _instagramApi = new InstagramAPI(_initProfileFields);
            _instagramApi.CreateConnect();
        }

        private void InitProfileFields()
        {
            UserNameLabel.Text = $"{_instagramApi._currentUser.UserName}";
            CountCurrentFollowersLabel.Text = $"{_instagramApi._countFollowers}";
        }

        private void InitImages()
        {
            ProfileImage.Source = ImageSource.FromFile("Profile.jpeg");
            FollowersImage.Source = ImageSource.FromFile("FollowerIcon.jpeg");
        }

        private void InitFollowersPricesListView()
        {
            _followersPrices = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "25", Price = "9.99$", Get = "Get" },
                new FollowerPrice { Count = "3", Price = "0.99$", Get = "Get" },
                new FollowerPrice { Count = "12", Price = "4.99$", Get = "Get" },
                new FollowerPrice { Count = "60", Price = "19.99$", Get = "Get" },
                new FollowerPrice { Count = "180", Price = "49.99$", Get = "Get" },
                new FollowerPrice { Count = "400", Price = "99.99$", Get = "Get" }
            };

            FollowersPricesListView.ItemsSource = _followersPrices;
        }
    }
}