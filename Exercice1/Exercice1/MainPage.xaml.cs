using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace Exercice1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int FontSize { get; set; }
        public List<string> Quotes { get; set; }
        public int CurrentQuoteIndex { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Quotes = new List<string>()
            {
                "To be or not to be. That is the question.",
                "The greatest glory in living lies not in never falling, but in rising every time we fall.",
                "Tell me and I forget. Teach me and I remember. Involve me and I learn.",
                "Success is not final; failure is not fatal: It is the courage to continue that counts.",
                "Try not to become a man of success. Rather become a man of value."
            };
            CurrentQuoteIndex = 0;

            DisplayQuote();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (CurrentQuoteIndex + 1 < Quotes.Count)
                CurrentQuoteIndex++;
            else
                CurrentQuoteIndex = 0;

            DisplayQuote();

        }

        private void DisplayQuote()
        {
            if (Quotes.Count > 0 && CurrentQuoteIndex < Quotes.Count)
            {
                lblQuotes.Text = Quotes[CurrentQuoteIndex];
            }

        }
    }
}
