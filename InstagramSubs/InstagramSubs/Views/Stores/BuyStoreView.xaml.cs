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
            FollowersPricesListView.ItemsSource = new List<FollowerPrice>
            {
                new FollowerPrice { Count = "1 200", Price = "9.99$" },
                new FollowerPrice { Count = "100", Price = "0.99$" },
                new FollowerPrice { Count = "520", Price = "4.99$" },
                new FollowerPrice { Count = "2 500", Price = "19.99$" },
                new FollowerPrice { Count = "7 500", Price = "49.99$" },
                new FollowerPrice { Count = "18 000", Price = "99.99$" }
            };
        }
    }
}