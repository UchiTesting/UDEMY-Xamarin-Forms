using PlaylistManager.VMs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlaylistManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaylistDetailPage : ContentPage
	{
		private PlayListVM _playlist;

		public PlaylistDetailPage(PlayListVM playlist)
		{
			_playlist = playlist;
			BindingContext = _playlist;

			InitializeComponent();
		}
	}
}