using PlaylistManager.Classes;
using PlaylistManager.VMs;

using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PlaylistManager
{
	public partial class MainPage : ContentPage
	{
		public MainPageVM ViewModel { get => BindingContext as MainPageVM; set => BindingContext = value; }
		public MainPage()
		{
			// Can replace BindingContext property as it is setting it.
			ViewModel = new MainPageVM(new PageService());

			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void PlaylistItem_Tapped(object sender, ItemTappedEventArgs e)
			=> ViewModel.SelectPlaylistCommand.Execute(e.Item);
	}
}
