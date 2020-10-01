using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace FirstApp
{
	public class SecondPage : ContentPage
	{
		public SecondPage()
		{
			Button learnMoreBtn = new Button
			{
				Text = "Learn More",
			};
			// Assign event handler to clicked event
			learnMoreBtn.Clicked += LearnMore;

			Button earnMoreBtn = new Button
			{
				Text = "Earn More"
			};
			// Assign event handler inline
			earnMoreBtn.Clicked += (sender, args) =>
			{
				earnMoreBtn.Text = "R65,000";
			};
			
			Image camera = new Image { Source = "camera.png", Aspect = Aspect.AspectFit};
			TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += async (sender, args) =>
			{
				Image image = (Image)sender;
				image.Opacity = 0.5;
				await Task.Delay(200);
				image.Opacity = 1;
			};
			camera.GestureRecognizers.Add(tapGestureRecognizer);

			Content = new ScrollView
			{
				Orientation = ScrollOrientation.Vertical, // This is actually the default orientation
				Content = new StackLayout
				{					
					Children = {
						earnMoreBtn,
						learnMoreBtn,
						new Button { Text = "Left Button", HorizontalOptions = LayoutOptions.End},
						new Button { Text = "From Right", HorizontalOptions = LayoutOptions.StartAndExpand},
						new Entry { Placeholder = "PIN", Keyboard = Keyboard.Numeric},
						new BoxView { Color = Color.Green, Margin = 10, HeightRequest = 100, WidthRequest = 100},
						new Image { Source = "monkey.png", Aspect = Aspect.AspectFit, HorizontalOptions = LayoutOptions.End},
						new Image { Source = ImageSource.FromUri(new Uri("https://tochukwu.xyz/img/logo.png"))},
						camera
				    } 
				}
			};
			Padding = new Thickness(10, 0, 10, 5);
		}


		private void LearnMore(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			button.Text = "AWS + Java";
		}
	}
}