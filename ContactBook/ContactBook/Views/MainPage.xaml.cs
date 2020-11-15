
using ContactBook.Models;

using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace ContactBook.Views
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> contacts;
        private int counter = 0;
        public MainPage()
        {
            InitializeComponent();
            contacts = new ObservableCollection<Contact>();
            ContactList.ItemsSource = contacts;
        }

        private async void AddContact_Clicked(object sender, System.EventArgs e)
        {
            // Should be creating a new instance of Contact and call the ContactDetail page.

            var contact = new Contact();

            var page = new ContactDetail(contact);
            page.ContactAdded += (src, c) =>
            {
                contact.Id = ++counter;
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;
                contact.Phone = c.Phone;
                contact.Email = c.Email;
                contact.IsBlocked = c.IsBlocked;

                contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ContactList.SelectedItem == null) return;

            var contact = e.SelectedItem as Contact;

            var page = new ContactDetail(contact);

            page.ContactUpdated += (src, c) =>
            {
                var contactToUpdate = (from ct in contacts
                                       where ct.Id == c.Id
                                       select ct).FirstOrDefault();

                if (contactToUpdate != null)
                {
                    UpdateContactByDatatypeTransfer(contact, c);
                    //UpdateContactByDatatypeTransfer(contactToUpdate, c);
                    System.Console.WriteLine(contactToUpdate);
                }
            };

            await Navigation.PushAsync(page);

            ContactList.SelectedItem = null;

        }

        private static void UpdateContactByDatatypeTransfer(Contact contactToUpdate, Contact c)
        {
            contactToUpdate.Id = c.Id;
            contactToUpdate.FirstName = c.FirstName;
            contactToUpdate.LastName = c.LastName;
            contactToUpdate.Phone = c.Phone;
            contactToUpdate.Email = c.Email;
            contactToUpdate.IsBlocked = c.IsBlocked;
        }

        private void DeleteContact_Clicked(object sender, System.EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as Contact;
            contacts.Remove(item);
        }

        private void DisplayContactDetails_Tapped(object sender, System.EventArgs e)
        {
        }
    }
}
