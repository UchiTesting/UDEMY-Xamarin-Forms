
using SimpleMasterDetail.Model;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {
            BindingContext = contact ?? throw new ArgumentNullException();

            InitializeComponent();
        }
    }
}