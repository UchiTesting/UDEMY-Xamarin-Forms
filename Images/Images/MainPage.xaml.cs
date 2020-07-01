using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Images
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            string uriString = "https://lorempixel.com/1920/1080/sports/7";

            // Noisy code
            //var imageSource = (UriImageSource)ImageSource.FromUri(new Uri(uriString));

            // Better code.
            var imageSource = new UriImageSource { Uri = new Uri(uriString) };
            imageSource.CachingEnabled = false;
            imageSource.CacheValidity = TimeSpan.FromDays(7.0);

            image.Source = imageSource;
            //image.Source = uriString; // Implicit conversion
        }
    }
}
