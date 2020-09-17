using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.ViewModels;


namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarPage : ContentPage
	{
		CarViewModel carViewModel;

		public CarPage()
		{
			InitializeComponent();

			/* Using a view model that implements the INotifyPropertyChanged interface */
			carViewModel = new CarViewModel { Make = "Toyota", Mileage = "15 000 km", Price = 96000 };
			CarWidget.BindingContext = carViewModel;
		}

		private void IncreasePrice(object sender, EventArgs args)
		{
			carViewModel.Price += 1000;
		}

		private void DecreasePrice(object sender, EventArgs args)
		{
			carViewModel.Price -= 1000;
		}
	}
}