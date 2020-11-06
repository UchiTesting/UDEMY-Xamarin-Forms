
using Xamarin.Forms;

namespace ToolbarDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void New_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("New item", "New Item", "OK");
        }

        private async void Edit_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Edit Item", "Edit item", "OK");
        }

        private async void Delete_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Delete Item", "Delete item", "OK");
        }
    }
}
