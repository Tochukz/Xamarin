using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DetailsApp.Views;

namespace DetailsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavPageMaster : ContentPage
	{
		public ListView ListView;

		public NavPageMaster()
		{
			InitializeComponent();

			BindingContext = new NavPageMasterViewModel();
			ListView = MenuItemsListView;
		}

		class NavPageMasterViewModel : INotifyPropertyChanged
		{
			public ObservableCollection<NavPageMasterMenuItem> MenuItems { get; set; }

			public NavPageMasterViewModel()
			{
				MenuItems = new ObservableCollection<NavPageMasterMenuItem>(new[]
				{
					new NavPageMasterMenuItem { Id = 0, Title = "About Page", TargetType = typeof(AboutPage) },
					new NavPageMasterMenuItem { Id = 1, Title = "Product List Page", TargetType = typeof(ProductListPage) },
					new NavPageMasterMenuItem { Id = 2, Title = "Settings Page", TargetType = typeof(SettingsPage) },					
				});
			}

			#region INotifyPropertyChanged Implementation
			public event PropertyChangedEventHandler PropertyChanged;
			void OnPropertyChanged([CallerMemberName] string propertyName = "")
			{
				if (PropertyChanged == null)
					return;

				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
			#endregion
		}
	}
}