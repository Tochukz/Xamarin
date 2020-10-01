using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstApp
{
	public class FirstPage : ContentPage
	{
		public FirstPage()
		{

			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Label for Big Text", HorizontalOptions = LayoutOptions.Center,  FontSize = 40, TextColor = Color.White},
					new Label { Text = "Label for small text \n having a multiple \n line of text", HorizontalOptions = LayoutOptions.Center, FontSize = 20, TextColor = Color.White},
					new Label { Text = "Lable 3", FontSize = Device.GetNamedSize(NamedSize.Header, Type.GetType("Label")), TextColor = Color.LightBlue },
					new Label { Text = "Bold and Italic", FontAttributes=FontAttributes.Bold | FontAttributes.Italic, FontSize = 25 },
					new Button { Text = "Go Forth", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))},
					new Button { Text = "Soon, very soon", BorderColor = Color.FromHex("#094830"), BorderWidth=5, TextColor = Color.FromRgba(109, 98, 150, 0.7)}
				}
			};

			BackgroundColor = Color.Black;
		}
	}
}