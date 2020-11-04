using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchicalNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        public ModalPage()
        {
            InitializeComponent();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            // Because it was called with PushModalAsync, similarly we need to add "Modal" to the pop method
            await Navigation.PopModalAsync();
        }
    }
}