using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagramSubs.ViewModels
{
    public class FollowersViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public FollowersViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));
        }
    }
}