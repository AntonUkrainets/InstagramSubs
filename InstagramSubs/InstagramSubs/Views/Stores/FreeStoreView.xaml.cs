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

            InitFreeShopItemsList();
        }

        private void InitFreeShopItemsList()
        {
            EarnsListView.ItemsSource = new List<FreeShop>
            {
                new FreeShop
                {
                    TypeEarnIcon = ImageSource.FromFile("Watch.png"),
                    TypeEarn = "Watch & Earn",
                    CountCoins = "+ 5",
                }
            };
        }
    }
}