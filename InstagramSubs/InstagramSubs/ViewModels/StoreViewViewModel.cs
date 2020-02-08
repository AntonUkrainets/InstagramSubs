using Prism.Navigation;

namespace InstagramSubs.ViewModels
{
    public class StoreViewViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public StoreViewViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
