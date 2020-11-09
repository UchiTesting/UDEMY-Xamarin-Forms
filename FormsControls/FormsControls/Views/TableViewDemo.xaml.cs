using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableViewDemo : ContentPage
    {
        public TableViewDemo()
        {
            InitializeComponent();
        }

        private void EntryCell_Completed(object sender, EventArgs e)
        {
            DisplayAlert("Entry completed", "Hello World", "OK");
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            //DisplayAlert("Switch moved", "...", "KO");
        }
    }
}