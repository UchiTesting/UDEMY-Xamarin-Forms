using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPicker : ContentPage
    {
        public NavigationPicker()
        {
            new NavigationPage(this);
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var page = new NavigationPickerDetail();
            page.ContactMethods.ItemSelected += (source, args) =>
            {
                contactMethod.Text = args.SelectedItem.ToString();

                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }
    }
}