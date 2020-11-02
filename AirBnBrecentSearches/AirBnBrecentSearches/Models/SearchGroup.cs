using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirBnBrecentSearches.Models
{
    class SearchGroup : List<SearchItem>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public SearchGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }

        public ObservableCollection<SearchItem> FilterByLocation(string searchedString)
        {

            return new ObservableCollection<SearchItem>(this.Where(s => s.Location.ToLower().Contains(searchedString.ToLower())));
        }
    }
}
