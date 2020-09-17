using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.ViewModels;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DevPage : ContentPage
	{
		string[] Levels = { "Developer", "Team Lead", "Solution Architech", "Technical Evangelist"};

		// DevViewModel devViewModel;

		DevViewModel2 devViewModel;

		public DevPage()
		{
			InitializeComponent();

		    //devViewModel = new DevViewModel { Position = Levels[0] };

			devViewModel = new DevViewModel2 { Position = Levels[0] };

			/* View level data binding */
			DevPosition.BindingContext = devViewModel;
		}

		private async void ShowPositionBtnClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Position", $"{devViewModel.Position}", "OK");
		}

		private async void ElevateBtnClicked(object sender, EventArgs args)
		{
			int upIndex = 0;

			for( int i=0; i < Levels.Length; i++)
			{
				if (Levels[i] == devViewModel.Position)
				{
					upIndex = i + 1;
					break;
				}
			}
			upIndex = upIndex > Levels.Length - 1 ? Levels.Length - 1 : upIndex; 


			devViewModel.Position = Levels[upIndex];
			await DisplayAlert("Elevated", $"{devViewModel.Position}", "OK");
		}
	}
}