using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ListApp.Models;

namespace ListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModelListPage : ContentPage
	{
		public ModelListPage()
		{
			InitializeComponent();

			List<Product> Products = new List<Product>
			{
				new Product { Title = "Watch", Description = "A device that tells time"},
				new Product { Title = "Ball", Description = "A round object used to play a game."},
				new Product { Title = "Phone", Description = "An electronic device for communication."},
			};

			ProductList.ItemsSource = Products;
		}

		private async void ProductListItemTapped(object sender, ItemTappedEventArgs e)
		{
			Product product = (Product)e.Item;
			await DisplayAlert("Product Picked", $"{product.Title} was tapped.", "OK");
			((ListView)sender).SelectedItem = null;
		}
	}
}