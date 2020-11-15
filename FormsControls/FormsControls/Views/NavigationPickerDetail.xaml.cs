using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPickerDetail : ContentPage
    {
        public NavigationPickerDetail()
        {
            InitializeComponent();

            listView.ItemsSource = new List<string>
            {
                "None","Email","SMS","Phone","Postal mail"
            };
        }

        // We declare a public property to make
        public ListView ContactMethods { get => listView; }
    }
}