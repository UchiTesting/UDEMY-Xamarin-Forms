using ContactBook.Models;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetail : ContentPage
    {

        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;
        public ContactDetail(Contact contact)
        {
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
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (!(!string.IsNullOrWhiteSpace(contact.FirstName) || !string.IsNullOrWhiteSpace(contact.LastName)))
            {
                await DisplayAlert("Invalid data", "Either the first or last name must be filled", "OK");
                return;
            }

            Console.WriteLine("Contact info: " + contact);

            if (contact.Id == 0)
            {
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated?.Invoke(this, contact);
            }

            Navigation.PopAsync();
        }
    }
}