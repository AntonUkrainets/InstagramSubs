using InstagramApiSharp.Classes.Models;
using InstagramSubs.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramSubs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentPage
    {
        private InstagramAPI _instagramApi;
        private InstaCurrentUser _currentUser;
        public SettingsView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _instagramApi = new InstagramAPI("Bobby_Layout", "Bobby.Layout");

            await LoadCurrentUserAsync();
            InitProfileSettingsData();
        }

        private async Task LoadCurrentUserAsync()
        {
            var getCurrentUserResult = await _instagramApi.GetCurrentUserAsync();

            _currentUser = getCurrentUserResult.Value;
        }

        private void InitProfileSettingsData()
        {
            ProfileSettingsImage.Source = _currentUser.ProfilePicture;
            ProfileNameLabel.Text = _currentUser.UserName;
        }
    }
}