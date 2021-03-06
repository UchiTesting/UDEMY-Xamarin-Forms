﻿using Lists.Models;

using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContextActionView : ContentPage
    {
        ObservableCollection<ContactGroup> ContactGroups { get; set; }
        public ContextActionView()
        {
            InitializeComponent();

            ContactGroups = new ObservableCollection<ContactGroup>
            {
                new ContactGroup("My cats", "M")
                {
                    new Contact{Name= "Maya", PhotoUrl="https://lorempixel.com/150/150/cats/1"},
                    new Contact{Name= "Cerise", PhotoUrl="https://lorempixel.com/150/150/cats/2", Status="I wantz my treatz!"},
                    new Contact{Name= "Liam", PhotoUrl="https://lorempixel.com/150/150/cats/3"}
                },
                new ContactGroup("Your cats", "Y")
                {
                    new Contact{Name= "Minou", PhotoUrl="https://lorempixel.com/150/150/cats/4"},
                    new Contact{Name= "Minette", PhotoUrl="https://lorempixel.com/150/150/cats/5"}
                }
            };

            listView.ItemsSource = GetGroupedList();
        }


        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //listView.SelectedItem = null; // To disable selection

            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void LoveCat_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var cat = menuItem.CommandParameter as Contact;

            DisplayAlert("Love cat", cat.Name, "OK");
        }
        private void CuddleCat_Clicked(object sender, EventArgs e)
        {
            var cat = (sender as MenuItem).CommandParameter as Contact;
            ContactGroup group = ContactGroups.First(g => g.Contains(cat));

            DisplayAlert("Cuddle cat goes to sleep now.", $"{cat.Name} from group {group.Title}", "OK");
            group.Remove(cat);
            // Awful code but forces the view to update.
            listView.ItemsSource = GetGroupedList("!");
            listView.ItemsSource = GetGroupedList();
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetGroupedList();

            //listView.IsRefreshing = false;
            listView.EndRefresh();
        }

        // Does not work with ObservableCollection but with list the update happens.
        private ObservableCollection<ContactGroup> GetGroupedList(string searchedText = null)
        {
            if (string.IsNullOrWhiteSpace(searchedText))
                return new ObservableCollection<ContactGroup>(ContactGroups.Where(cg => cg.Count > 0));

            var tmpList = new ObservableCollection<ContactGroup>();


            for (int i = 0; i < ContactGroups.Count; i++)
            {
                var filteredCollection = ContactGroups[i].FilterByName(searchedText);
                if (filteredCollection.Count > 0)
                {

                    var collectionGroup = new ContactGroup(ContactGroups[i].Title, ContactGroups[i].ShortTitle);
                    collectionGroup.AddRange(filteredCollection);

                    tmpList.Add(collectionGroup);
                }
            }

            return tmpList;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetGroupedList(e.NewTextValue);
        }
    }
}