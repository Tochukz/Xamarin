using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurvyApp
{
	public partial class App : Application
	{
		public App()
		{
			Device.SetFlags(new string[] { "Shapes_Experimental"});

			InitializeComponent();

			//MainPage = new MainPage();
			MainPage = new NavigationPage(new MainPage());
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
