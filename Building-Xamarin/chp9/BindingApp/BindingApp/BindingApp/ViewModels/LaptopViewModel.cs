using System;
using System.Collections.Generic;
using System.Text;
using BindingApp.Models;

namespace BindingApp.ViewModels
{
	class LaptopViewModel
	{
		Laptop laptop;

		public LaptopViewModel()
		{
			laptop = new Laptop();
		}

		public string Brand
		{
			set => laptop.Brand = value;
			get => laptop.Brand;
		}

		public string HDD
		{
			set => laptop.HDD = value;
			get => laptop.HDD;
		}

		public int Price
		{
			set
			{
				laptop.Price = value;
				laptop.OnPropertyChanged("Price");
			}

			get => laptop.Price;
		}
	}
}
