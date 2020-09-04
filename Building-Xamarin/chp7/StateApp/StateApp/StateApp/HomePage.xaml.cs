using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StateApp.Models;

namespace StateApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			/* Setting Global Property Dictionary */
			Application.Current.Properties["AppName"] = "State App";
			Application.Current.Properties["AppVersion"] = "Version 0.0.1";
			Application.Current.Properties["AppCreator"] = "Chucks Nwachukwu";

			/* Setting properties for the Global class (StateApp.Global) */
			Global global = Global.GetInstance;
			global.HDD = "1 Tera Byte";
			global.RAM = "16 GB";
			global.Screen = "18 Inches";
		}

		private async void GotoUserDetails(object sender, EventArgs args)
		{
			User user = new User() { Name = "Tochukwu", Email = "tochukwu.me@gmail.com", City = "Cape Town", Salary = 55000 }; 
			await Navigation.PushAsync(new UserPage(user));
		}

		private async void GotoHelp(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new HelpPage());
		}

		private async void GotoSpect(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new SpecificationPage());
		}
	}
}