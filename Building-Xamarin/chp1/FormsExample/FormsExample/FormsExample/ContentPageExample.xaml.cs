using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentPageExample : ContentPage
	{
		public ContentPageExample()
		{
			InitializeComponent();
		}

		protected void ButtonClicked(object sender, EventArgs args)
		{
			((Button)sender).Text = "You 've got it";
		}

		protected void ImageTapped(object sender, EventArgs args)
		{
			Image image = ((Image)sender);
			image.Source = image.Source.ToString() == "logo.png" ? ImageSource.FromFile("logo_black.png") : ImageSource.FromFile("logo.png"); // Does not work fully.
		}

		async protected void PhotoImageTapped(object sender, EventArgs args)
		{
			Image image = (Image)sender;
			/*
			image.Opacity = 0.1;
			await Task.Delay(200);
			image.Opacity = 1;
			*/

			await image.FadeTo(0.5, 450);
			await Task.Delay(200);
			await image.FadeTo(1, 450);
		}
	}
}