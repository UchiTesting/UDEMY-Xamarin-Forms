﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorView : ContentPage
    {
        public ActivityIndicatorView()
        {
            InitializeComponent();

            //image.Source = ImageSource.FromResource("Images.Images.background.jpg");
        }
    }
}