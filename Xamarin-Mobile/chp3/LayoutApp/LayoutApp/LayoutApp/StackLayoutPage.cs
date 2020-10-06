using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp
{
	public class StackLayoutPage : ContentPage
	{
		
		public StackLayoutPage()
		{
			StackLayout stackVetical = new StackLayout { BackgroundColor = Color.LightGreen, Spacing = 0, Padding = new Thickness(10, 0, 10, 5)};
			stackVetical.Children.Add(new Label { Text = "Left Label", HorizontalOptions = LayoutOptions.Start, BackgroundColor = Color.AliceBlue });
			stackVetical.Children.Add(new Label { Text = "Center Label", HorizontalOptions = LayoutOptions.Center, BackgroundColor = Color.Aqua });
			stackVetical.Children.Add(new Label { Text = "Right Label", HorizontalOptions = LayoutOptions.End, BackgroundColor = Color.Purple });
			stackVetical.Children.Add(new Label { Text = "Fill Label", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.AntiqueWhite });
			stackVetical.Children.Add(new Label { Text = "Fill + Expand", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Red });
			stackVetical.Children.Add(new Label { Text = "Start + Expand", HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.Indigo });
			stackVetical.Children.Add(new Label { Text = "Default Label", BackgroundColor = Color.Violet });

			StackLayout stackHorizontal = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Bisque,
				Spacing = 0,
				Padding = new Thickness(10, 0, 10, 5),
				Children =
				{
					new Label { Text = "Left Label", HorizontalOptions = LayoutOptions.Start, BackgroundColor = Color.FromHex("#347a73")},
					new Label { Text = "Full Label", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.FromHex("#84834f")},
					new Label { Text = "Center Label", HorizontalOptions = LayoutOptions.Center, BackgroundColor = Color.FromRgb(156, 98, 199)},
					new Label { Text = "Right Label", HorizontalOptions = LayoutOptions.End, BackgroundColor = Color.Azure}
				}
			};

			Content = new StackLayout
			{   
				BackgroundColor = Color.LightBlue,
				Children = {
					stackVetical,
					stackHorizontal
				}
			};
		}
	}
}