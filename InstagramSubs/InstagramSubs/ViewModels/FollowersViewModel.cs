using InstagramSubs.Model;
using InstagramSubs.Views;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramSubs.ViewModels
{
    public class FollowersViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        private ICommand _navigatePayView;
        public ICommand NavigatePayView => _navigatePayView
            ?? (_navigatePayView = new Command<Price>(OnNavigationPayView));

        public FollowersViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private void OnNavigationPayView(Price price)
        {
            var navigationParameters = new NavigationParameters
                    {
                        { "countFollowers", price }
                    };

            _navigationService.NavigateAsync(nameof(PayView), navigationParameters);
        }
    }
}