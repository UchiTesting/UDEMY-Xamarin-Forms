using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace PlaylistManager.VMs
{
	public class PlayListVM : INPCImpl
	{
		string title;
		public string Title { get => title; set => SetValue(ref title, value); }

		bool isFavourited;
		public bool IsFavourited
		{
			get => isFavourited;
			set { SetValue(ref isFavourited, value); OnPropertyChanged(nameof(Colour)); }
		}

		public Color Colour
		{
			get => IsFavourited ? Color.DodgerBlue : Color.Black;
			//set => SetValue(ref colour, value);
		}

		public override string ToString()
		{
			return $"Playlist {Title} favourited: {IsFavourited}";
		}
	}
}
