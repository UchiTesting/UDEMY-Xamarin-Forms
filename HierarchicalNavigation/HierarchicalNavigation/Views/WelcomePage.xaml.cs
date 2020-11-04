
using Xamarin.Forms;

namespace HierarchicalNavigation.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void GoToIntroPage_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new IntroductionPage());
        }

        public async void GoToModalPage_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ModalPage());
        }
    }
}
