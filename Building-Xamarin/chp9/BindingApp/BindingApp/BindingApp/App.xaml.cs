using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindingApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new MainPage();
			MainPage = new EditableObservableBookListPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
