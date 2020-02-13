using InstagramSubs.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Prism.Ioc;
using InstagramSubs.API;
using System.Threading.Tasks;
using Prism.Navigation;

namespace InstagramSubs.Views
{
    public partial class PayView : ContentPage, INavigationAware
    {
        private InstagramAPI _instagramApi;
        private UserContext _userContext;

        public PayView()
        {
            InitializeComponent();

            InitCardsList();
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var order = parameters.GetValue<Order>("countFollowers");

            CountFollowersLabel.Text = $"{order.CountFollowers}";
            PayButton.Text += order.Cost;
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

            InitCountFollowersLabel();
        }

        private void InitCountFollowersLabel()
        {
            CountFollowersLabel.Text = $"{_userContext.Followers.Count}";
        }

        private async Task LoadAsync()
        {
            var getCurrentUserFollowersResult = await _instagramApi.GetCurrentUserFollowersAsync();
            _userContext.Followers = getCurrentUserFollowersResult.Value;
        }

        private void InitCardsList()
        {
            CardsListView.ItemsSource = new List<Card>
            {
                new Card
                {
                    Name = "Card",
                    Icon = ImageSource.FromFile("Card.png")
                },
                new Card
                {
                    Name = "In-App Purchase",
                    Icon = ImageSource.FromFile("CardAppStore.jpg")
                }
            };
        }
    }
}