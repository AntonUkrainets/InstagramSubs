using InstagramSubs.Model.SettingItems;
using InstagramSubs.Views;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramSubs.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private ICommand _navigateHelperView;
        public ICommand NavigateHelperView => _navigateHelperView
            ?? (_navigateHelperView = new Command(OnNavigationHelperView));

        private INavigationService _navigationService;
        public SettingsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }

        private void OnNavigationHelperView()
        {
            _navigationService.NavigateAsync(nameof(HelperView));
        }
    }
}