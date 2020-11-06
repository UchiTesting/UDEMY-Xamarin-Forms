using InstagramLike.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramLike.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            BindingContext = Data.GetMyProfile();
            InitializeComponent();
        }
    }
}