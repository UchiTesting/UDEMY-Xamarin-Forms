using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace LuckyNumber
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            LblNumber.Text = rnd.Next(0, (int)Slider.Value + 1).ToString();
        }
    }
}
