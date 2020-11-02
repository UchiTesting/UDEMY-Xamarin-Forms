
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            //btn.Image = (FileImageSource) ImageSource.FromFile(
            //    Device.OnPlatform(
            //        iOS: "clock.png",
            //        Android: "clock.png"
            //        //,WinPhone: "Images/clock.png"
            //        ));
        }
    }
}