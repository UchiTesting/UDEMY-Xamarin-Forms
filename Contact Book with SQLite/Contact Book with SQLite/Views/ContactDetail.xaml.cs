using Contact_Book_with_SQLite.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact_Book_with_SQLite.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetail : ContentPage
	{
		public ContactDetail()
		{
			var contact = new Contact();
			InitializeComponent();
		}
	}
}