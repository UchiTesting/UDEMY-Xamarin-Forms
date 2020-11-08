
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FormsControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pickers : ContentPage
    {
        public Pickers()
        {
            InitializeComponent();

            GetSomething().ForEach(i => TonguePicker.Items.Add(i.Data));
        }

        private IList<Something> GetSomething()
        {
            return new List<Something> {
                new Something{Id=1, Data="English"},
                new Something{Id=2, Data="Français"},
                new Something{Id=2, Data="Polski"},
                new Something{Id=2, Data="Lëtzebuergesch"},
                new Something{Id=5, Data="日本語"},
            };
        }

        private void MethodPicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var method = MethodPicker.Items[MethodPicker.SelectedIndex];

            LabelDisplay.Text = "Method picked: " + method;
        }

        private void TonguePicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var tongue = TonguePicker.Items[TonguePicker.SelectedIndex];
            LabelDisplay.Text = "Tongue picked: " + tongue;

        }
    }

    public class Something
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}