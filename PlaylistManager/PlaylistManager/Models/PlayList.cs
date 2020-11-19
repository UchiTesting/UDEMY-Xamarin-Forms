using Xamarin.Forms;

namespace PlaylistManager.Models
{
	public class PlayList : INPCImpl
	{
		public string Title { get ; set ; }
		public bool IsFavourited { get; set ; }
		
		public override string ToString()
		{
			return $"Playlist {Title} favourited: {IsFavourited}";
		}
	}
}
