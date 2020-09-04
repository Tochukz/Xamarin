using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigationApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private async void ToContactPage(object sender, EventArgs args)
		{
			//await Navigation.PushAsync(new ContactPage());
			await Navigation.PushAsync(new ContactPage(), true);						
		}

		private async void Navigate(object sender, EventArgs args)
		{
			string typeString = (string)((ToolbarItem)sender).CommandParameter;
			Type type = Type.GetType($"NavigationApp.{typeString}");
			Page page = (Page)Activator.CreateInstance(type);
			await Navigation.PushAsync(page);
		}

		private async void ShowAlert(object sender, EventArgs args)
		{
			bool proceed = await DisplayAlert("Payment Continue", "Do you want to proceed?", "Yes", "No");
			if (proceed == true)
			{
				await DisplayAlert("Payment Confimation", "Payment was successful", "Ok");
			}
		}

		private async void ShowActionSheet(object sender, EventArgs args)
		{
			string selectedOption = await DisplayActionSheet("Lnaguage", "Cancel", null, "JavaScript", "PHP", "C#", "C++");
			OptionTxt.Text = selectedOption;
		}
	}
}