using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp
{
	public class FramePage : ContentPage
	{
		public FramePage()
		{
			Padding = 20;
			Content = new Frame
			{
				BorderColor = Color.Blue,
				HasShadow = true,
				Content = new StackLayout {
					Children = { 
						new Label { Text = "Frame Page" } 
					}
				}
			};
		}
	}
}