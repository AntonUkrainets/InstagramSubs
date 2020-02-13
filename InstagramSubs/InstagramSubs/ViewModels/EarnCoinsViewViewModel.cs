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
    public class EarnCoinsViewViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private ICommand _skipSubUser;
        public ICommand SkipSubUser => _skipSubUser
            ?? (_skipSubUser = new Command<string>(OnSkipSubUser));

        public EarnCoinsViewViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }

        private void OnSkipSubUser(string obj)
        {
            
        }
    }
}