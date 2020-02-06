using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.SessionHandlers;
using InstagramApiSharp.Logger;
using InstagramSubs.API;
using InstagramSubs.Model;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FollowersView : ContentPage
    {
        private InstagramAPI _instagramAPI;

        private ICollection<FollowerPrice> FollowersPrices { get; set; }

        public FollowersView()
        {
            InitializeComponent();

            InitImages();

            InitFollowersPricesListView();

            _instagramAPI = new InstagramAPI();
            _instagramAPI.CreateConnect();
        }

        private void InitImages()
        {
            ProfileImage.Source = ImageSource.FromFile("Profile.jpeg");
            FollowersImage.Source = ImageSource.FromFile("FollowerIcon.jpeg");
        }

        private void InitFollowersPricesListView()
        {
            FollowersPrices = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "25", Price = "9.99$", Get = "Get" },
                new FollowerPrice { Count = "3", Price = "0.99$", Get = "Get" },
                new FollowerPrice { Count = "12", Price = "4.99$", Get = "Get" },
                new FollowerPrice { Count = "60", Price = "19.99$", Get = "Get" },
                new FollowerPrice { Count = "180", Price = "49.99$", Get = "Get" },
                new FollowerPrice { Count = "400", Price = "99.99$", Get = "Get" }
            };

            FollowersPricesListView.ItemsSource = FollowersPrices;
        }
    }
}
