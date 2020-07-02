using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page0 : ContentPage
    {
        public Page0()
        {
            InitializeComponent();
            string uriString = "https://mobimg.b-cdn.net/lwallpaper_img/landscape_by_live_wallpaper_hd_3d/real/2_landscape_by_live_wallpaper_hd_3d.jpg";

            // Noisy code
            //var imageSource = (UriImageSource)ImageSource.FromUri(new Uri(uriString));

            // Better code.
            var imageSource = new UriImageSource { Uri = new Uri(uriString) };
            imageSource.CachingEnabled = false;
            imageSource.CacheValidity = TimeSpan.FromSeconds(1.0);

            image.Source = imageSource;
            //image.Source = uriString; // Implicit conversion
        }
    }
}