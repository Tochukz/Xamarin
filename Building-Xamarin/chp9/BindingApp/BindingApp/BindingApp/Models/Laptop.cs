using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingApp.Models
{
	class Laptop: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string brand;

		string hdd;
		
		int price;

		public string Brand
		{
			set
			{
				if (!value.Equals(brand, StringComparison.Ordinal))
				{
					brand = value;
					OnPropertyChanged("Brand");
				}
			}
			get
			{
				return brand;
			}
		}


		public string HDD
		{
			set
			{
				if (!value.Equals(hdd, StringComparison.Ordinal))
				{
					hdd = value;
					OnPropertyChanged("HDD");
				}
			}
			get
			{
				return hdd;
			}
		}

		public int Price
		{
			set
			{
				if (!value.Equals(price))
				{
					price = value;
					OnPropertyChanged("Price");
				}
			}
			get
			{
				return price;
			}
		}



		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
