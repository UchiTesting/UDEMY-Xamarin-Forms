using ContactBook.Models;
using ContactBook.Persistence;

using SQLite;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> contacts;
        private SQLiteAsyncConnection cnx;
        private bool isDataLoaded;
        public MainPage()
        {
            InitializeComponent();

            cnx = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            if (isDataLoaded) return;

            isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await cnx.CreateTableAsync<Contact>();

            var contacts = await cnx.Table<Contact>().ToListAsync();

            this.contacts = new ObservableCollection<Contact>(contacts);
            ContactsLV.ItemsSource = this.contacts;
        }

        private async void contactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ContactsLV.SelectedItem == null) return;

            var selectedContact = e.SelectedItem as Contact;

            ContactsLV.SelectedItem = null;

            var page = new DetailContactPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new DetailContactPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Do you really want to delete {contact.FullName}?", "Yes", "No"))
            {
                contacts.Remove(contact);

                await cnx.DeleteAsync(contact);
            }
        }
    }
}
