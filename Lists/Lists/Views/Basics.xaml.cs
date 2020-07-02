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

            var contactGroups = new List<ContactGroup>
            {
                new ContactGroup("My cats", "M")
                {
                    new Contact{Name= "Maya", PhotoUrl="https://lorempixel.com/150/150/cats/1"},
                    new Contact{Name= "Cerise", PhotoUrl="https://lorempixel.com/150/150/cats/2", Status="I wantz my treatz!"},
                    new Contact{Name= "Liam", PhotoUrl="https://lorempixel.com/150/150/cats/3"}
                },
                new ContactGroup("Your cats", "Y")
                {
                    new Contact{Name= "Minou", PhotoUrl="https://lorempixel.com/150/150/cats/4"},
                    new Contact{Name= "Minette", PhotoUrl="https://lorempixel.com/150/150/cats/5"}
                }
            };

            listView.ItemsSource = contactGroups;
        }
    }
}