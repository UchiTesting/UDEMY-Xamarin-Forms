
using MasterDetail.Model;

using System;

using Xamarin.Forms;

namespace MasterDetail.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {
            // Equivalent to
            // if (contact == null)
            //     throw new ArgumentNullException();
            //
            // BindingContext = contact;
            BindingContext = contact ?? throw new ArgumentNullException();

            InitializeComponent();
        }
    }
}