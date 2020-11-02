using ContactBook.Models;
using ContactBook.Persistence;

using SQLite;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailContactPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        private SQLiteAsyncConnection _connection;

        public DetailContactPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Firstname and lastname can't be empty.", "OK");
                return;
            }

            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);

                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);

                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}