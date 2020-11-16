
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{

		public Page1()
		{
			InitializeComponent();

			/// In the App class, we defined fields and properties to work with the Application.Properties dictionary.
			/// By defining the Binding context to it, we can use these properties directly in XAML for binding.
			BindingContext = Application.Current;
		}

		// The code bellow would have been here without binding.

		//private void Title_Completed(object sender, System.EventArgs e)
		//{
		//	Application.Current.Properties["Title"] = Title.Text;
		//}

		//private void NotificationEnabled_OnChanged(object sender, ToggledEventArgs e)
		//{
		//	Application.Current.Properties["NotifEnabled"] = NotificationEnabled.On;
		//}
	}
}