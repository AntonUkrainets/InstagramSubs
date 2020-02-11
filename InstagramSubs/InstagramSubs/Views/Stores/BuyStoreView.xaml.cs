using InstagramSubs.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace InstagramSubs.Views.Stores
{
    public partial class BuyStoreView : ContentPage
    {
        public BuyStoreView()
        {
            InitializeComponent();

            InitFollowersPricesList();
        }

        private void InitFollowersPricesList()
        {
            FollowersPricesListView.ItemsSource = new List<Price>
            {
                new Price { CountFollowers = "1 200", Cost = "9.99$" },
                new Price { CountFollowers = "100", Cost = "0.99$" },
                new Price { CountFollowers = "520", Cost = "4.99$" },
                new Price { CountFollowers = "2 500", Cost = "19.99$" },
                new Price { CountFollowers = "7 500", Cost = "49.99$" },
                new Price { CountFollowers = "18 000", Cost = "99.99$" }
            };
        }
    }
}