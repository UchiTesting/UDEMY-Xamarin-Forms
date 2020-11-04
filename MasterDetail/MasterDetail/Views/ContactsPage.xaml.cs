using MasterDetail.Model;

using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterDetail.Views
{
    public partial class ContactsPage : MasterDetailPage
    {
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage(new ContactDetailPage(contact));
            IsPresented = false;
        }

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
    }
}

