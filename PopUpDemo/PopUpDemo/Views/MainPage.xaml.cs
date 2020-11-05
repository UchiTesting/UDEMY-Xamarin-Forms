
using Xamarin.Forms;

namespace PopUpDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void DisplayPopUp_Clicked(object sender, System.EventArgs e)
        {
            var response = await DisplayAlert("Available options", "Any message can be set here", "I'm good", "I'm bad");

            if (response)
                await DisplayAlert("Good one", "Here is a sweet for you.", "OK");
            else
                await DisplayAlert("Bad one", "Here is morue oil for you.", "OK");
        }

        private async void DisplayActionSheet_Clicked(object sender, System.EventArgs e)
        {
            var response = await DisplayActionSheet("Nuke the world", "I'm not insane.", "Just go for it!", new string[] { "Ask a friend for advice", "50/50", "Ask the audience" });
            await DisplayAlert("Response", response, "OK");
        }
    }
}
