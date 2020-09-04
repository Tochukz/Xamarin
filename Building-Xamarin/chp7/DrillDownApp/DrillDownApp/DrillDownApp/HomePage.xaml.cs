using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrillDownApp.Models;

namespace DrillDownApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			List<PageModel> pages = new List<PageModel>
			{
				new PageModel { Title = "Book List", PageType = typeof(BookListPage) },
				new PageModel { Title = "About the App", PageType = typeof(AboutPage) }
			};

			PageList.ItemsSource = pages;
		}		

		private async void ToPage(object sender, ItemTappedEventArgs e)
		{
			PageModel pageModel = e.Item as PageModel;
			Page page = (Page) Activator.CreateInstance(pageModel.PageType);
			await Navigation.PushAsync(page);
			((ListView)sender).SelectedItem = null;
		}

		private async void GotoPage(object sender, EventArgs e)
		{
			string pageString = (string)((TextCell)sender).CommandParameter;
			Type pageType = Type.GetType($"DrillDownApp.{pageString}Page");
			Page page = (Page)Activator.CreateInstance(pageType);
			await Navigation.PushAsync(page);
		}

	}
}