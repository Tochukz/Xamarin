using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExamplePage : ContentPage
	{
		public ExamplePage()
		{
			InitializeComponent();
		}

		protected void ButtonClicked(object sender, EventArgs args)
		{
			((Button)sender).Text = "It is so!";
		}
	}
}