using InstagramSubs.Model;
using InstagramSubs.Model.SettingItems;
using Prism.Ioc;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentPage
    {
        private UserContext _userContext;

        public SettingsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _userContext = App.Current.Container.Resolve<UserContext>();

            InitProfileSettingsData();

            InitShopsList();
        }

        private void InitShopsList()
        {
            ShopsList.ItemsSource = new List<BuyShop>
            {
                new BuyShop { Name = "Coins Store", Image = ImageSource.FromFile("Store.jpg") },
                new BuyShop { Name = "Free Coins", Image = ImageSource.FromFile("FreeStore.jpg") },
                new BuyShop { Name = "Settings", Image = ImageSource.FromFile("SettingsIcon.jpg") }
            };
        }

        private void InitProfileSettingsData()
        {
            ProfileSettingsImage.Source = _userContext.User.AvatarUri;
            ProfileNameLabel.Text = _userContext.User.Name;
        }
    }
}