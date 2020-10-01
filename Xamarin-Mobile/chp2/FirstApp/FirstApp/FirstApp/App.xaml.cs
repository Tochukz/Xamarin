using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// MainPage = new MainPage();
			/*
			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children =
					{
						new Label
						{
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms in C#"
						}
					}
				}
			};
			*/

			//MainPage = new FirstPage();
			MainPage = new SecondPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
			// Called when the App is moved to the background by the user selected another app 
			// Also called when the App is terminated
		}

		protected override void OnResume()
		{
			// Called when the app is brought to the foreground by the user selecting the App.
		}
	}
}
