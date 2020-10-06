using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp
{
	public class RelativeLayoutPage : ContentPage
	{
		public RelativeLayoutPage()
		{
			Label upperLeft = new  Label
			{
				Text = "Upper Left",
				FontSize = 20,
				BackgroundColor  = Color.Red,
				WidthRequest = 100,
				HeightRequest = 30,
			};
			BoxView box = new BoxView { BackgroundColor = Color.Blue };
			Label halfWayDown = new Label { Text = "Half way down", BackgroundColor = Color.Green };
			Label belowHalfWay = new Label { Text = "Below Halfway", BackgroundColor = Color.White };


			/* Constaint syntax */
			//relativeLayout.Children.Add(view, xLocationConstraint, yLocationConstraint, widthConstraint, heightConstraint)

			RelativeLayout relativeLayout = new RelativeLayout() { BackgroundColor = Color.Orange };

			/* Absolute constraint */
			relativeLayout.Children.Add(upperLeft, Constraint.Constant(0), Constraint.Constant(0));
			relativeLayout.Children.Add(box, Constraint.Constant(100), Constraint.Constant(30), Constraint.Constant(200), Constraint.Constant(100));

			/* Constraint relative to parent */
			relativeLayout.Children.Add(halfWayDown, Constraint.RelativeToParent(parent => parent.Width / 2), Constraint.RelativeToParent(parent => parent.Height / 2));

			/* Constraint relative to sibling */
			relativeLayout.Children.Add(belowHalfWay, Constraint.Constant(0), Constraint.RelativeToView(halfWayDown, (parent, sibling) => sibling.Y + sibling.Height));

			Content = relativeLayout;
		}
	}
}