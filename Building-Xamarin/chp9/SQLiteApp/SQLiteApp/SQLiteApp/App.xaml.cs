using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using SQLiteApp.Data;

namespace SQLiteApp
{
	public partial class App : Application
	{
		static BookDatabase database;

		public static BookDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new BookDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.db3"));
				}
				return database;
			}
		}

		public App()
		{
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
