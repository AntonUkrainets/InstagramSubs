using Prism;
using Prism.Ioc;
using InstagramSubs.ViewModels;
using InstagramSubs.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InstagramSubs.API;
using InstagramSubs.Model;
using InstagramSubs.Views.Stores;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InstagramSubs
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");

            //await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(FollowersView));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<InstagramAPI>(
                new InstagramAPI("Genry_Layout", "Genry.Layout")
                );

            containerRegistry.RegisterSingleton<UserContext>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FollowersView, FollowersViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<StoreView, StoreViewViewModel>();
            containerRegistry.RegisterForNavigation<BuyStoreView, BuyStoreViewViewModel>();
            containerRegistry.RegisterForNavigation<FreeStoreView, FreeStoreViewViewModel>();
        }
    }
}