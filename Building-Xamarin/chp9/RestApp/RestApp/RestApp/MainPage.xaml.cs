using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

using Newtonsoft.Json;
using RestApp.Models;

namespace RestApp
{
	public partial class MainPage : ContentPage
	{
		
		public  MainPage()
		{
			InitializeComponent();
		}

		private async void ToPage(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			string pageTypeStr = (string)button.CommandParameter;
			Type type = Type.GetType($"RestApp.{pageTypeStr}");
			Page page = (Page)Activator.CreateInstance(type);
			await Navigation.PushAsync(page);
;		}
	}
}
