using DataAccess.Persistance;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page4 : ContentPage
	{
		public Page4()
		{
			InitializeComponent();

			// Tells to use the platform specific implementation of generic type IFileSystem.
		}

		private void EntryField_Completed(object sender, System.EventArgs e)
		{
			var fileSystem = DependencyService.Get<IFileSystem>();

			fileSystem.WriteTextAsync("test.txt", EntryField.Text);

		}
	}
}