using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entries : ContentPage
    {
        public Entries()
        {
            InitializeComponent();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            LabelPhone.Text = "Completed";
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelMail.Text = e.NewTextValue;
        }
    }
}