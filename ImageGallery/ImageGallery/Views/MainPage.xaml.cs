using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace ImageGallery.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly List<UriImageSource> webImages;
        int CurrentIndex;
        public MainPage()
        {
            webImages = new List<UriImageSource>{
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/tokyo"),CachingEnabled = false},
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/osaka"),CachingEnabled = false},
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/kyoto"),CachingEnabled = false},
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/kamakura"),CachingEnabled = false},
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/krakow"),CachingEnabled = false},
                new UriImageSource{Uri=new Uri("https://loremflickr.com/320/240/cat"),CachingEnabled = false}
            };
            CurrentIndex = 0;


            Console.WriteLine($"Number of items in the gallery: {webImages.Count}");

            InitializeComponent();

            UpdateImage();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            if (CurrentIndex < webImages.Count - 1)
                CurrentIndex++;
            else
                CurrentIndex = 0;

            Console.WriteLine($"Current index: {CurrentIndex}");
            UpdateImage();
        }

        private void Previous_Clicked(object sender, EventArgs e)
        {
            if (CurrentIndex > 1)
                CurrentIndex--;
            else
                CurrentIndex = webImages.Count - 1;

            Console.WriteLine($"Current index: {CurrentIndex}");
            UpdateImage();
        }

        private void UpdateImage()
        {
            if (CurrentIndex >= 0 && CurrentIndex <= webImages.Count - 1)
                image.Source = webImages[CurrentIndex];
            else
                Console.WriteLine($"idx: {CurrentIndex}");
        }
    }
}
