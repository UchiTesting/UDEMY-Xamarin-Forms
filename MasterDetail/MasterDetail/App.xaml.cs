using MasterDetail.Views;

using Xamarin.Forms;

namespace MasterDetail
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContactsPage();
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
