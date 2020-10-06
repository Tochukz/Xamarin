using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using LayoutApp.Controls;

namespace LayoutApp
{
	public class ContentViewPage : ContentPage
	{
		public ContentViewPage()
		{
			ContentView contentView = new ContentView
			{
				BackgroundColor = Color.Teal,
				Padding = new Thickness(40),
				HorizontalOptions = LayoutOptions.Fill,
				Content = new Label
				{
					Text = "Label in Content View in Line",
					FontSize = 20,
					FontAttributes = FontAttributes.Bold,
					TextColor = Color.Wheat
				}
			};

			Padding = new Thickness(10, 20, 10, 5);
			Content = new StackLayout
			{
				Children = {
					contentView,
					new BoxContentView(),
				}
			};
		}
	}
}