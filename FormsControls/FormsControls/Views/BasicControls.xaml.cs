
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicControls : ContentPage
    {
        public BasicControls()
        {
            InitializeComponent();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            SwitchLabel1.Text = (e.Value) ? "On" : "Off";
        }
    }
}