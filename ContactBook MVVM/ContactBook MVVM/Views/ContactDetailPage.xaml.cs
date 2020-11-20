using Xamarin.Forms;

namespace ContactBookMVVM
{
	public partial class ContactDetailPage : ContentPage
	{
		public ContactDetailPage(ContactDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = viewModel;
		}
	}
}