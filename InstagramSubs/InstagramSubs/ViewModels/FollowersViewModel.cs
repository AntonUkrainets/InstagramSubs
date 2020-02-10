using InstagramSubs.Model;
using InstagramSubs.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramSubs.ViewModels
{
    public class FollowersViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        private ICommand _navigatePayView;
        //public ICommand NavigatePayView => _navigatePayView
        //    ?? (_navigatePayView = new Command(OnNavigationPayView));

        private ICommand _buttonCommand;
        public ICommand GoToPayView
        {
            get
            {
                return new Command<string>((string data) =>
                {
                    var navigationParameters = new NavigationParameters
                    {
                        { "countFollowers", data }
                    };

                    _navigationService.NavigateAsync(nameof(PayView), navigationParameters);
                });
            }
        }

        public ICommand NavigatePayView
        {
            get
            {
                return new Command<object>((object value) =>
                {
                    var data = value;

                    var navigationParameters = new NavigationParameters
                    {
                        { "countFollowers", data }
                    };

                    _navigationService.NavigateAsync(nameof(PayView), navigationParameters);
                });
            }
        }

        public FollowersViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private void OnNavigationPayView(object obj)
        {
            var v = obj as FollowerPrice;

            _navigationService.NavigateAsync(nameof(PayView));
        }
    }
}