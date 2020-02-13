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
            FollowersPricesListView.ItemsSource = new List<Order>
            {
                new Order { CountFollowers = "1 200", Cost = "9.99$" },
                new Order { CountFollowers = "100", Cost = "0.99$" },
                new Order { CountFollowers = "520", Cost = "4.99$" },
                new Order { CountFollowers = "2 500", Cost = "19.99$" },
                new Order { CountFollowers = "7 500", Cost = "49.99$" },
                new Order { CountFollowers = "18 000", Cost = "99.99$" }
            };
        }
    }
}