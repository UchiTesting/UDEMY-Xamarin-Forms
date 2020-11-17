using Contact_Book_with_SQLite.Models;

using System;
using System.Collections.ObjectModel;
using System.Text;

using Xamarin.Forms;

namespace Contact_Book_with_SQLite
{
	public partial class MainPage : ContentPage
	{
		private ObservableCollection<Contact> contacts;
		private int counter;
		public MainPage()
		{
			InitializeComponent();
			contacts = new ObservableCollection<Contact>();
			counter = 0;

			ContactList.ItemsSource = contacts;
		}

		private void DeleteContact_Clicked(object sender, EventArgs e)
		{
			var contact = (sender as MenuItem).CommandParameter as Contact;
			if (contacts.Contains(contact))
				contacts.Remove(contact);
		}

		private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (ContactList.SelectedItem == null) return;

			var contact = e.SelectedItem as Contact;

			var page = new Views.ContactDetail(contact);
			page.ContactUpdated += (src, c) =>
			{
				UpdateContactByDatatypeTransfer(contact, c);
			};

			await Navigation.PushAsync(page);

			ContactList.SelectedItem = null;

		}

		private async void AddContact_Clicked(object sender, EventArgs e)
		{
			var contact = new Contact();

			var page = new Views.ContactDetail(contact);

			page.ContactAdded += (src, c) =>
			{
				UpdateContactByDatatypeTransfer(contact, c);

				contact.Id = ++counter;
				contacts.Add(contact);
			};

			await Navigation.PushAsync(page);

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

		private string GenerateRandomPhone()
		{
			var r = new Random();

			StringBuilder result = new StringBuilder();
			result.Append("03");

			for (int i = 0; i < 8; i++)
			{
				result.Append(r.Next(10));
			}

			return result.ToString();
		}

		private string GenerateRandomString()
		{
			var r = new Random();
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < 5; i++)
			{
				result.Append(Char.ConvertFromUtf32(r.Next(97, 123)));
			}

			return result.ToString();
		}

		private string GenerateRandomEmail()
		{
			return $"{GenerateRandomString()}@{GenerateRandomString()}.com";
		}
	}
}
