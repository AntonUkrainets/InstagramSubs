using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagramSubs.ViewModels
{
    public class HelperViewViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public HelperViewViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}