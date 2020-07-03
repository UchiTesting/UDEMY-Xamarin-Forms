using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lists.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicsView : ContentPage
    {ObservableCollection<Contact> Contacts { get; set; }
        public BasicsView()
        {
            InitializeComponent();

            Contacts = new ObservableCollection<Contact>
            {

                    new Contact{Name= "Maya", PhotoUrl="https://lorempixel.com/150/150/cats/1"},
                    new Contact{Name= "Cerise", PhotoUrl="https://lorempixel.com/150/150/cats/2", Status="I wantz my treatz!"},
                    new Contact{Name= "Liam", PhotoUrl="https://lorempixel.com/150/150/cats/3"},
                    new Contact{Name= "Minou", PhotoUrl="https://lorempixel.com/150/150/cats/4"},
                    new Contact{Name= "Minette", PhotoUrl="https://lorempixel.com/150/150/cats/5",Status="I iz cuddly."}
            };

            listView.ItemsSource = GetContacts();
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

            DisplayAlert("Cuddle cat goes to sleep now.", $"{cat.Name}", "OK");
            Contacts.Remove(cat);
            listView.ItemsSource = GetContacts();
        }

        private ObservableCollection<Contact> GetContacts(string searchText = null) {

            if (string.IsNullOrWhiteSpace(searchText))
                return Contacts;

            var tmpList = new ObservableCollection<Contact>(Contacts.Where(c => c.Name.ToLower().StartsWith(searchText.ToLower())));

            return tmpList;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}