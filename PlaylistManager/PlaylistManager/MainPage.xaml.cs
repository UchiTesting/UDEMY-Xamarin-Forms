using PlaylistManager.Models;
using PlaylistManager.VMs;

using System;

using Xamarin.Forms;

namespace PlaylistManager
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new MainPageVM();

			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void AddPlaylist_Clicked(object sender, EventArgs e)
			=> (BindingContext as MainPageVM).AddPlayList();

		private void PlaylistItem_Tapped(object sender, ItemTappedEventArgs e)
			=> (BindingContext as MainPageVM).PlaylistTapped(e.Item as PlayListVM);
	}
}
