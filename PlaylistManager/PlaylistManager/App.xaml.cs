
using Xamarin.Forms;

namespace PlaylistManager
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// Navigation page is needed to see toolbars
			MainPage = new NavigationPage(new MainPage());
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
