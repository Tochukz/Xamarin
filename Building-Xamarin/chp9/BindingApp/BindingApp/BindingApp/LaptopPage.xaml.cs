using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.Models;
using BindingApp.ViewModels;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaptopPage : ContentPage
	{
		Laptop laptop;

		//LaptopViewModel laptop;

		public LaptopPage()
		{
			InitializeComponent();

			/* Using a data model that implements the INotifyPropertyChanged interface. This desgin does not conform with the MVVM pattern */
			laptop = new Laptop { Brand = "Dell", HDD = "1 Tera Byte", Price = 20000 };

			/* Using a view model that wraps a data model which implements the INotifyPropertyChanged interface. */
			// This method is not working for 2-way non-trivial binding, the view is not being update when the model property chnages 
			//laptop =  new LaptopViewModel { Brand = "HP", HDD = "500 Mega Bytes", Price = 5000 };

			LaptopWidget.BindingContext = laptop;
		}

		private void DecreasePrice(object sender, EventArgs args)
		{
			laptop.Price -= 100;
		}

		private void IncreasePrice(object sender, EventArgs args)
		{
			laptop.Price += 100;
		}
	}
}