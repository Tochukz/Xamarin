using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavPage : MasterDetailPage
	{
		public NavPage()
		{
			InitializeComponent();
			MasterPage.ListView.ItemSelected += ListView_ItemSelected;
		}

		public void SetDetailsPage(Page page)
		{
			Detail = new NavigationPage(page);
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as NavPageMasterMenuItem;
			if (item == null)
				return;

			var page = (Page)Activator.CreateInstance(item.TargetType);
			page.Title = item.Title;

			Detail = new NavigationPage(page);
			IsPresented = false;

			MasterPage.ListView.SelectedItem = null;
		}
	}
}