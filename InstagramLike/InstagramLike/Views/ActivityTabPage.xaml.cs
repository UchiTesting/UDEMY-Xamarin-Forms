
using InstagramLike.Model;
using InstagramLike.Service;

using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramLike.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityTabPage : MasterDetailPage
    {
        public ActivityTabPage()
        {
            InitializeComponent();
            //notifList.ItemsSource = new List<object> { new { Message = "Item 1" }, new { Message = "Item 2" } };

            var items = Data.GetNotifications().ToList();

            //items.ForEach(i => System.Console.WriteLine($"DEBUG: {i.Id} {i.Message} {i.UserId} {i.UserImage}"));

            notifList.ItemsSource = items;
        }

        private void NotifList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var notif = e.SelectedItem as Notification;
            var user = Data.GetUserById(notif.UserId);
            Detail = new NavigationPage(new ProfileDetailPage(user));
            IsPresented = false;
        }
    }
}