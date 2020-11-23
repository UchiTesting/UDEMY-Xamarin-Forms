using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeyondBasics.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagingCenterDetail : ContentPage
	{
		//public event EventHandler<double> ValueUpdated;
		public MessagingCenterDetail()
		{
			InitializeComponent();
		}

		private async void BackToDemo_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			// if using Events...
			//ValueUpdated?.Invoke(this, slider.Value);

			// With messaging center
			MessagingCenter.Send(this, Events.SliderValueChanged, e.NewValue);
		}
	}
}