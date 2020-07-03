using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirBnBrecentSearches.Models;

using Xamarin.Forms;

namespace AirBnBrecentSearches
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly ObservableCollection<RecentSearchGroup> recentSearches;
        public MainPage()
        {
            recentSearches = FullGroupedCollection();
            InitializeComponent();

            listView.ItemsSource = GetRecentSeaches();
        }

        ObservableCollection<RecentSearchGroup> GetRecentSeaches(string searchedString = null)
        {
            if (string.IsNullOrWhiteSpace(searchedString))
                return recentSearches;
            else
            {
                var tmpList = new ObservableCollection<RecentSearchGroup>();

                for (int i = 0; i < recentSearches.Count; i++)
                {
                    var filteredCollection = recentSearches[i].FilterByLocation(searchedString);
                    if (filteredCollection.Count > 0)
                    {
                        var collectionGroup = new RecentSearchGroup(recentSearches[i].Title, recentSearches[i].ShortTitle);
                        collectionGroup.AddRange(filteredCollection);

                        tmpList.Add(collectionGroup);
                    }

                }

                return tmpList;
            }
        }

        ObservableCollection<RecentSearchGroup> FullGroupedCollection()
        {
            var collection = new ObservableCollection<RecentSearchGroup>
            {
                  new RecentSearchGroup("Recent searches", "S")
                  {
                      new SearchItem{StartDate="03/07/2020",EndDate="03/08/2020",Location="Metz, Grand-Est, France"},
                      new SearchItem{StartDate="13/08/2020",EndDate="13/09/2020",Location="Thionville, Grand-Est, France"},
                      new SearchItem{StartDate="23/01/2021",EndDate="23/02/2021",Location="Albertville, Auvergne-Rhône-Alpes, France"},
                      new SearchItem{StartDate="03/07/2021",EndDate="03/08/2021",Location="Trucville, Fakelands, Mars"},
                      new SearchItem{StartDate="30/12/2025",EndDate="03/01/2026",Location="ZorgTown, FakeCountries, Jupiter"}
                  }
           };

            return collection;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetRecentSeaches(e.NewTextValue);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var searchItem = e.SelectedItem as SearchItem;
            Console.WriteLine("Selected", searchItem.Location, "OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var searchItem = e.Item as SearchItem;
            Console.WriteLine("Tapped", searchItem.Dates, "OK");
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetRecentSeaches();

            //listView.IsRefreshing = false;
            listView.EndRefresh();
        }

        private void HackEntry_Clicked(object sender, EventArgs e)
        {
            var searchItem = (sender as MenuItem).CommandParameter as SearchItem;
            RecentSearchGroup group = recentSearches.First(g => g.Contains(searchItem));

            //DisplayAlert("Deleting an element.", $"{searchItem.Location} from group {group.Title}", "OK");
            group.Remove(searchItem);
            // Awful code but forces the view to update.
            listView.ItemsSource = GetRecentSeaches("!");
            listView.ItemsSource = GetRecentSeaches();
        }
    }
}
