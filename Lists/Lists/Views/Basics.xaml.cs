using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lists.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Basics : ContentPage
    {
        public Basics()
        {
            InitializeComponent();

            var contactGroups = new List<ContactGroup>
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

            listView.ItemsSource = contactGroups;
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
    }
}