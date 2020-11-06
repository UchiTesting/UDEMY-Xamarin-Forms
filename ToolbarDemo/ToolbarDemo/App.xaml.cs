
using ToolbarDemo.Views;

using Xamarin.Forms;

namespace ToolbarDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Toolbars needs a navigation page to display
            MainPage = new NavigationPage(new MainPage());
            // Change to this code is you want to observe it by yourself.
            //MainPage = new MainPage();
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
