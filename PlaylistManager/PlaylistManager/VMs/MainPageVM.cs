using PlaylistManager.Classes;
using PlaylistManager.Views;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace PlaylistManager.VMs
{
	public class MainPageVM : INPCImpl
	{
		private readonly IPageService _pageService;

		#region ICommand implementation
		public ICommand AddPlaylistCommand { get; private set; }
		public ICommand SelectPlaylistCommand { get; private set; }
		#endregion

		ObservableCollection<PlayListVM> playLists;
		public ObservableCollection<PlayListVM> PlayLists
		{
			get => playLists;
			private set => SetValue(ref playLists, value);
		}

		private PlayListVM selectedPlaylist;
		public PlayListVM SelectedPlaylist
		{
			get => selectedPlaylist;
			set => SetValue(ref selectedPlaylist, value);
		}

		private void AddPlayList()
		{
			var newPlaylist = new PlayListVM { Title = $"Playlist {DateTime.Now:G}", IsFavourited = false };
			playLists.Add(newPlaylist);
		}

		private async Task PlaylistTapped(PlayListVM p)
		{
			if (p == null) return;


			// Action performed after it had been selected.
			//p.IsFavourited = !p.IsFavourited;

			SelectedPlaylist = null;

			var page = new PlaylistDetailPage(p);

			//page.UpdatedPlaylist += (src, args) =>
			//{
			//	p.Title = args.Title;
			//	p.IsFavourited = args.IsFavourited;
			//};

			await _pageService.PushAsync(page);
		}

		public MainPageVM(IPageService pageService)
		{
			_pageService = pageService;
			PlayLists = new ObservableCollection<PlayListVM>();
			AddPlaylistCommand = new Command(AddPlayList);
			SelectPlaylistCommand = new Command<PlayListVM>(async vm => await PlaylistTapped(vm));
		}
	}
}
