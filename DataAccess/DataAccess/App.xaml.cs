
using DataAccess.Views;

using Xamarin.Forms;

namespace DataAccess
{
	public partial class App : Application
	{
		#region Property keys
		private const string TitleKey = "Name";
		private const string NotificationsKey = "NotificationsEnabled";
		#endregion

		#region Properties Properties (C# properties to deal with properties of the app.)
		public string Title

		{
			get
			{
				if (Properties.ContainsKey(TitleKey))
					return Properties[TitleKey].ToString();
				else
					return "";
			}
			set
			{
				Properties[TitleKey] = value;
			}
		}

		public bool NotificationsEnabled
		{
			get
			{
				if (Properties.ContainsKey(NotificationsKey))
					return (bool)Properties[NotificationsKey];
				else
					return true;
			}
			set
			{
				Properties[NotificationsKey] = value;
			}
		}
		#endregion
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
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
