
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public Page1()
        {
            InitializeComponent();

            BindingContext = Application.Current;
        }
    }
}