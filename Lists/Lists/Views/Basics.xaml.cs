using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lists.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Basics : ContentPage
    {
        public Basics()
        {
            InitializeComponent();

            var contacts = new List<Contact>
            {
                new Contact{Name= "Maya", PhotoUrl="https://lorempixel.com/100/100/cats/1"},
                new Contact{Name= "Cerise", PhotoUrl="https://lorempixel.com/100/100/cats/2", Status="I wantz my treatz!"},
                new Contact{Name= "Liam", PhotoUrl="https://lorempixel.com/100/100/cats/3"}
            };

            listView.ItemsSource = contacts;
        }
    }
}