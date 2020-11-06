using InstagramLike.Model;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramLike.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetailPage : ContentPage
    {
        public ProfileDetailPage(User user)
        {
            BindingContext = user ?? throw new ArgumentNullException();

            InitializeComponent();
        }
    }
}