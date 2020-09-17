using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.Models;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarListPage : ContentPage
	{
		public CarListPage()
		{
			InitializeComponent();

			List<Car> CarList = new List<Car>
			{
				new Car { Make = "Toyota", Mileage = "12 000 km", Price = 98000},
				new Car { Make = "Nissan", Mileage = "37 000 km", Price = 128000},
				new Car { Make = "Benz", Mileage = "60 000 km", Price = 108000}
			};

			CarListView.ItemsSource = CarList;
		}

		private async void CarListItemTapped(object sender, ItemTappedEventArgs e)
		{
			Car car = (Car)e.Item;
			await DisplayAlert("Car Selected", $"You Choose a {car.Make}", "OK");
			((ListView)sender).SelectedItem = null;
		}
	}
}