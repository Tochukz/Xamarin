using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StringListPage : ContentPage
	{
		
		public StringListPage()
		{
			InitializeComponent();

			List<String> Items = new List<string>
			{
				"Fish",
				"Bread",
				"Chiken",
				"Pizza"
			};

			BindingContext = Items;
		}

		protected async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
		{
			string item = (string)e.Item;
			await DisplayAlert("Item Tapped", $"{item} was tapped", "OK");
			((ListView)sender).SelectedItem = null;
		}

		protected async void ListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			string item = (string)e.SelectedItem;
			await DisplayAlert("Item Selected", $"{item} was selcted", "OK");
			((ListView)sender).SelectedItem = null;

		}
	}
}