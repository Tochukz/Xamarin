using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingApp.ViewModels
{
	class DevViewModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string position;

		public string Position
		{
			set
			{
				if (!value.Equals(position, StringComparison.Ordinal))
				{
					position = value;
					onPropertyChanged("Position");					
				}
			}
			get
			{
				return position;
			}
		}

		void onPropertyChanged([CallerMemberName] string propertyName = null)
		{
			/*
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
			*/

			/* Simplified delegate invocation */
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
