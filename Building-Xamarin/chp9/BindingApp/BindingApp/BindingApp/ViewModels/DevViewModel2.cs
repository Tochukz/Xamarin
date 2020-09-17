using System;
using System.Collections.Generic;
using System.Text;

namespace BindingApp.ViewModels
{
	class DevViewModel2: BindableBase
	{
		string position;

		public string Position
		{
			set
			{
				if (!value.Equals(position, StringComparison.Ordinal))
				{
					position = value;
					OnPropertyChanged("Position");
				}
			}
			get
			{
				return position;
			}
		}
	}
}
