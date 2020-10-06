using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp
{
	public class AbsoluteLayoutPage : ContentPage
	{
		public AbsoluteLayoutPage()
		{
			AbsoluteLayout absoluteLayout = new AbsoluteLayout();
			StackLayout headerStack = new StackLayout
			{
				BackgroundColor = Color.LightBlue,
				Orientation = StackOrientation.Horizontal,
				Children = {
					new Label { Text = "Header Label", BackgroundColor = Color.Red }
				}
			};
			StackLayout footerstack = new StackLayout
			{
				BackgroundColor = Color.DarkGreen,
				Children =
				{
					new Label { Text = "Footer Label", BackgroundColor = Color.Blue }
				}
			};

			Label bodyLabel = new Label { Text = "Body Label", BackgroundColor = Color.Yellow };

			/* Syntax for absolute layout */
			// absoluteLayout.Children.Add (firstLabel, new Rectangle (xCoordinate, yCoordinate, xWidth, xHeight), AbsoluteLayoutFlags); 
			// Note that HorizontalOptions, VerticalOptions, and Expand layout options are overridden by absolute positioning
			absoluteLayout.Children.Add(headerStack, new Rectangle(0, 0, 1, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.WidthProportional);
			absoluteLayout.Children.Add(footerstack, new Rectangle(0, 1, 1, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

			Content = absoluteLayout;
		}
	}
}