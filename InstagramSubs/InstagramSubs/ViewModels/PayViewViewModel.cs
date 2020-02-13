using InstagramSubs.Model;
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
    public class PayViewViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private readonly UserContext _userContext;
        private ICommand _pay;
        public ICommand Pay => _pay
            ?? (_pay = new Command<string>(OnPay));

        public PayViewViewModel(INavigationService navigationService, UserContext userContext)
            : base(navigationService)
        {
            _navigationService = navigationService
                ?? throw new ArgumentNullException(nameof(_navigationService));

            this._userContext = userContext;

            //_userContext = App.Current.Container.Resolve<UserContext>();
        }

        private void OnPay(string obj)
        {
            var uc = this._userContext;
        }
    }
}