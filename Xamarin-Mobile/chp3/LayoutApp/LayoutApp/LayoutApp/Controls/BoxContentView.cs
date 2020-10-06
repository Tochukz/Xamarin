using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp.Controls
{
	public class BoxContentView : ContentView
	{
		public BoxContentView()
		{
			BackgroundColor = Color.Cyan;
			Padding = new Thickness(40);
			HorizontalOptions = LayoutOptions.Fill;
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Single File Content View" }
				}
			};
		}
	}
}