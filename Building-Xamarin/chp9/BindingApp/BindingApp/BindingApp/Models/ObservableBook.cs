using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingApp.Models
{
	class ObservableBook: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string title;

		string description;

		public string Title
		{
			set
			{
				if (!value.Equals(title, StringComparison.Ordinal))
				{
					title = value;
					OnPropertyChanged("Title");
				}
			}
			get => title;
		}

		public string Description
		{
			set
			{
				if (!value.Equals(description, StringComparison.Ordinal))
				{
					description = value;
					OnPropertyChanged("Description");
				}
			}
			get => description;
		}

		public int BookId { set; get; }

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
