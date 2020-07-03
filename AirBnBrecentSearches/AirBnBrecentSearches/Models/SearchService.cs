using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AirBnBrecentSearches.Models
{
    class SearchService
    {
        private static readonly ObservableCollection<SearchGroup> recentSearches = FullGroupedCollection();
        public static ObservableCollection<SearchGroup> GetRecentSeaches(string searchedString = null)
        {
            if (string.IsNullOrWhiteSpace(searchedString))
                return recentSearches;
            else
            {
                var tmpList = new ObservableCollection<SearchGroup>();

                for (int i = 0; i < recentSearches.Count; i++)
                {
                    var filteredCollection = recentSearches[i].FilterByLocation(searchedString);
                    if (filteredCollection.Count > 0)
                    {
                        var collectionGroup = new SearchGroup(recentSearches[i].Title, recentSearches[i].ShortTitle);
                        collectionGroup.AddRange(filteredCollection);

                        tmpList.Add(collectionGroup);
                    }

                }

                return tmpList;
            }
        }

        public static void DeleteSearch(SearchItem searchItem)
        {
            SearchGroup group = recentSearches.First(g => g.Contains(searchItem));

            //DisplayAlert("Deleting an element.", $"{searchItem.Location} from group {group.Title}", "OK");
            group.Remove(searchItem);
        }

        static ObservableCollection<SearchGroup> FullGroupedCollection()
        {
            var collection = new ObservableCollection<SearchGroup>
            {
                  new SearchGroup("Recent searches", "S")
                  {
                      new SearchItem{CheckIn="03/07/2020",CheckOut="03/08/2020",Location="Metz, Grand-Est, France"},
                      new SearchItem{CheckIn="13/08/2020",CheckOut="13/09/2020",Location="Thionville, Grand-Est, France"},
                      new SearchItem{CheckIn="23/01/2021",CheckOut="23/02/2021",Location="Albertville, Auvergne-Rhône-Alpes, France"},
                      new SearchItem{CheckIn="03/07/2021",CheckOut="03/08/2021",Location="Trucville, Fakelands, Mars"},
                      new SearchItem{CheckIn="30/12/2025",CheckOut="03/01/2026",Location="ZorgTown, FakeCountries, Jupiter"}
                  }
           };

            return collection;
        }
    }
}
