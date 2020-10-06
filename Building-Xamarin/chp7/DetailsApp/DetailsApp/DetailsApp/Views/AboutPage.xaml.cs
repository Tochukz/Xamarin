using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

		private void ProductListPage(object sender, EventArgs args)
		{
			((NavPage)App.Current.MainPage).SetDetailsPage(new ProductListPage());
		}
	}

}