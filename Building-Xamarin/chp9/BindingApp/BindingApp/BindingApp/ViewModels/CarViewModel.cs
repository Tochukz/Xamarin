using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using BindingApp.Models;

namespace BindingApp.ViewModels
{
	class CarViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		Car car;

		public CarViewModel()
		{
			car = new Car();
		}

		public string Make
		{
			set
			{
				if (!value.Equals(car.Make, StringComparison.Ordinal))
				{
					car.Make = value;
				}
			}
			get
			{
				return car.Make;
			}
		}

		public string Mileage
		{
			set
			{
				if (!value.Equals(car.Mileage, StringComparison.Ordinal))
				{
					car.Mileage = value;
				}
			}
			get
			{
				return car.Mileage;
			}
		}

		public int Price
		{
			set
			{
				if (!value.Equals(car.Price))
				{
					car.Price = (int)value;
					OnPropertyChanged("Price");
				}
			}
			get
			{
				return car.Price;
			}
		}


		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
