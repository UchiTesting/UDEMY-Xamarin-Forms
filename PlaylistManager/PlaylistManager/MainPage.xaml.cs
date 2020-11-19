using PlaylistManager.Classes;
using PlaylistManager.VMs;

using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PlaylistManager
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new MainPageVM(new PageService());

			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void AddPlaylist_Clicked(object sender, EventArgs e)
			=> (BindingContext as MainPageVM).AddPlayList();

		private async void PlaylistItem_Tapped(object sender, ItemTappedEventArgs e)
			=> await (BindingContext as MainPageVM).PlaylistTapped(e.Item as PlayListVM);
	}
}
