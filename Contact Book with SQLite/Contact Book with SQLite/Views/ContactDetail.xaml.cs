using Contact_Book_with_SQLite.Classes;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact_Book_with_SQLite.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetail : ContentPage
	{
		private Contact contact;
		public event EventHandler<Contact> ContactAdded;
		public event EventHandler<Contact> ContactUpdated;

		public ContactDetail(Contact c)
		{
			contact = c;
			BindingContext = contact;
			InitializeComponent();
		}

		private async void SaveContactData_Clicked(object sender, System.EventArgs e)
		{
			// Check if at least one of First of Last name have been set.
			if (String.IsNullOrWhiteSpace(FirstNameEntry.Text) && String.IsNullOrWhiteSpace(LastNameEntry.Text))
			{
				await DisplayAlert("Data validation", "At least one of first or last name must be set", "OK");
				return;

			}

			// Send relevent event according to current situation.
			if (contact.Id == 0)
			{
				ContactAdded?.Invoke(this, contact);
			}
			else
			{
				ContactUpdated?.Invoke(this, contact);
			}

			await Navigation.PopAsync();
		}
	}
}