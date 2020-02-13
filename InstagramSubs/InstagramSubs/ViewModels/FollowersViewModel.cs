using InstagramSubs.Model;
using InstagramSubs.Views;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramSubs.ViewModels
{
    public class FollowersViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private ICommand _navigatePayView;
        public ICommand NavigatePayView => _navigatePayView
            ?? (_navigatePayView = new Command<Order>(OnNavigationPayView));

        public FollowersViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private void OnNavigationPayView(Order order)
        {
            var navigationParameters = new NavigationParameters
                    {
                        { "countFollowers", order }
                    };

            _navigationService.NavigateAsync(nameof(PayView), navigationParameters);
        }
    }
}