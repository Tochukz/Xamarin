using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSSApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new CSSPage();
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
