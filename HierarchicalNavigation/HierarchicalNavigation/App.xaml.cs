
using HierarchicalNavigation.Views;

using Xamarin.Forms;

namespace HierarchicalNavigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*
             * You can define the main page here.
             * Initially It was WelcomePage().
             * To enable navigation you must surround that with
             * NavigationPage(). That's it.
             */
            MainPage = new NavigationPage(new WelcomePage())
            {
                BarBackgroundColor = Color.DeepSkyBlue,
                BarTextColor = Color.YellowGreen
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
