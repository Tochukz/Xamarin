﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EffectsApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new MainPage();
			//MainPage = new LoginPage();
			MainPage = new UsingAttachedPropertyPage();
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
