using PlaylistManager.Models;

using System;
using System.Collections.ObjectModel;

namespace PlaylistManager.VMs
{
	public class MainPageVM : INPCImpl
	{
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

		public void AddPlayList()
		{
			var newPlaylist = new PlayListVM { Title = $"Playlist {DateTime.Now:G}", IsFavourited = false };
			playLists.Add(newPlaylist);
		}

		public void PlaylistTapped(PlayListVM p)
		{
			if (p == null) return;


			// Action performed after it had been selected.
			p.IsFavourited = !p.IsFavourited;

			SelectedPlaylist = null;

		}

		public int LastSelectedIndex { get; set; }

		public MainPageVM()
		{
			PlayLists = new ObservableCollection<PlayListVM>();
			LastSelectedIndex = -1;
		}
	}
}
