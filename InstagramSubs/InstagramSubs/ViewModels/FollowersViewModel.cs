using InstagramSubs.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramSubs.ViewModels
{
    public class FollowersViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private ICommand _navigatePayView;
        public ICommand NavigatePayView => _navigatePayView
            ?? (_navigatePayView = new Command(OnNavigationPayView));

        public FollowersViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private void OnNavigationPayView(object obj)
        {
            _navigationService.NavigateAsync(nameof(PayView));
        }
    }
}