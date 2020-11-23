using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeyondBasics.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagingCenterDemo : ContentPage, INotifyPropertyChanged
	{
		double theValue;
		public double TheValue
		{
			get => theValue;
			set
			{
				theValue = value;
				label.Text = theValue.ToString();
			}
		}
		public MessagingCenterDemo()
		{
			BindingContext = this;
			InitializeComponent();
		}

		private async void DisplayDetail_Clicked(object sender, EventArgs e)
		{
			var page = new MessagingCenterDetail();

			// Using Events to share data between pages
			//page.ValueUpdated += OnSliderValueChanged;

			// Using MessagingCenter to share data between parts of the application
			MessagingCenter.Subscribe<MessagingCenterDetail, double>(this, Events.SliderValueChanged, OnSliderValueChangedMsg);

			await Navigation.PushAsync(page);

			MessagingCenter.Unsubscribe<MessagingCenterDemo>(this, "SliderValueChanged");
		}

		private void OnSliderValueChanged(object sender, double args) => TheValue = args;
		private void OnSliderValueChangedMsg(MessagingCenterDetail sender, double args) => TheValue = args;
	}
}