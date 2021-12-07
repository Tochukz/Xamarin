using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CurvyApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public async void toShapPage(object sender, EventArgs args)
		{
		    await Navigation.PushAsync(new ShapesPage(), true);
		}
	}
}
