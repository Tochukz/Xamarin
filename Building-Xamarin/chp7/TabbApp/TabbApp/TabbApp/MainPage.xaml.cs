using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabbApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			/* Using the tap gesture recognizer */
			TapGestureRecognizer tapRecognizer = new TapGestureRecognizer();
			tapRecognizer.Tapped += async (sender, evt) =>
			{
				// For visual responsive effect
				Image image = (Image)sender;
				image.Opacity = 0.5;
				await Task.Delay(500);
				image.Opacity = 1;

				// Now navigation to the page
				await Navigation.PushAsync(new ProfilePage());
			};
			ProfileImage.GestureRecognizers.Add(tapRecognizer);
		}

		private async void GotoPage(object sender, EventArgs e)
		{
			string pageStr = (string)((Button)sender).CommandParameter;
			Type type = Type.GetType($"TabbApp.{pageStr}");
			Page page = (Page)Activator.CreateInstance(type);
			await Navigation.PushAsync(page);
		}
	}
}
