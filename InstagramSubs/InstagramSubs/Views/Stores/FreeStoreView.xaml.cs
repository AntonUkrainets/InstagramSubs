using InstagramSubs.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace InstagramSubs.Views.Stores
{
    public partial class FreeStoreView : ContentPage
    {
        public FreeStoreView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitEarnsListView();
        }

        private void InitEarnsListView()
        {
            EarnsListView.ItemsSource = new List<FreeShop>
            {
                new FreeShop
                {
                    TypeEarnIcon = ImageSource.FromFile("Wach.png"),
                    TypeEarn = "Watch & Earn",
                    CountCoins = "+ 5",
                    CoinsIcon = ImageSource.FromFile("Coins.png")
                }
            };
        }
    }
}