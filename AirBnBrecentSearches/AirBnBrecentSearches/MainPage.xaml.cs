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
        public MainPage()
        {
            InitializeComponent();

            listView.ItemsSource = SearchService.GetRecentSeaches();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = SearchService.GetRecentSeaches(e.NewTextValue);
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
            listView.ItemsSource = SearchService.GetRecentSeaches(searchBar.Text);

            //listView.IsRefreshing = false;
            listView.EndRefresh();
        }

        private void HackEntry_Clicked(object sender, EventArgs e)
        {
            var searchItem = (sender as MenuItem).CommandParameter as SearchItem;
            SearchService.DeleteSearch(searchItem);

            // Awful code but forces the view to update.
            listView.ItemsSource = SearchService.GetRecentSeaches("!");
            listView.ItemsSource = SearchService.GetRecentSeaches(searchBar.Text);
        }
    }
}
