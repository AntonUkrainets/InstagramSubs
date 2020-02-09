using InstagramSubs.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace InstagramSubs.Views
{
    public partial class PayView : ContentPage
    {
        public PayView()
        {
            InitializeComponent();

            InitCardsList();
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