using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsExample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// MainPage = new MainPage();
			MainPage = new ContentPageExample();
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
