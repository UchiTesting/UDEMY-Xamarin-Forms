using SimpleMasterDetail.Model;
using SimpleMasterDetail.Views;

using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<Contact>
            {
                new Contact{ Name="Clara", Status="", Age=30, Id=1,
                    ImageUrl="https://lorempixel.com/100/100/people/1"},
                new Contact{ Name="Mosh", Status="Excellent Teacher", Age=45, Id=2,
                    ImageUrl="https://lorempixel.com/100/100/people/3"},
                new Contact{ Name="Me", Status="Working hard on getting better",Age=38, Id=3,
                    ImageUrl="https://lorempixel.com/100/100/cats/8"},
            };
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new ContactDetailPage(contact));

            // If not here when coming back from detail page, the item is still selected.
            // This triggers another time this method. Hence the null check in its beginning.
            listView.SelectedItem = null;
        }
    }
}