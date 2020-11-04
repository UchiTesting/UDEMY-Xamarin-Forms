using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchicalNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroductionPage : ContentPage
    {
        public IntroductionPage()
        {
            InitializeComponent();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        /*
         * For Android and Windows Phone the OS provide a back button
         * Should we hide the back button from the navigation bar in the app,
         * we could still get to the previous page using the OS back button.
         * 
         */
        protected override bool OnBackButtonPressed()
        {
            // Default behaviour can be replaced
            //return base.OnBackButtonPressed();

            // Superceded default behaviour and does nothing. This deactivate the back button from the OS.
            return true;
        }
    }
}