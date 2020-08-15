using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RelativeLayoutPage : ContentPage
	{
		public RelativeLayoutPage()
		{
			InitializeComponent();

			Label below = new Label
			{
				Text = "Below Upper Left",
				BackgroundColor = Color.Purple,
				FontSize = 15
			};

			LayoutContainer.Children.Add(
				below, 
				Constraint.Constant(0), 
				Constraint.RelativeToView(UpperLeft, (parent, sibing) => {
					return sibing.Y + sibing.Height;
				}
		    ));
		}
	}
}