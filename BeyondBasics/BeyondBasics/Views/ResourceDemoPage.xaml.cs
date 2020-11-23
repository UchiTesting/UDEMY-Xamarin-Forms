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
	public partial class ResourceDemoPage : ContentPage
	{
		public ResourceDemoPage()
		{
			InitializeComponent();
		}

		private void ChangeColour_Clicked(object sender, EventArgs e)
		{
			// If there are multiple resource dictionaries, it doesn't work. Probably because it cannot tell which one
			// needs to be updated.
			Resources["buttonBgColour"] = Color.DodgerBlue;
		}
	}
}