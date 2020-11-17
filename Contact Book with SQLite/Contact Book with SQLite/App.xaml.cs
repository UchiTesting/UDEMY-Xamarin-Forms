
using Xamarin.Forms;

namespace Contact_Book_with_SQLite
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// NavigationPage is needed in order to see the toolbar.
			MainPage = new NavigationPage(new Views.ContactDetail());
			//MainPage = new NavigationPage(new MainPage());
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
