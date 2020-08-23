using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TemplateApp.Controls;

namespace TemplateApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			//Todo: Learn hw to use the control in the xaml page
			CardView AnotherCard = new CardView
			{
				BorderColor = Color.DarkGray,
				CardTitle = "Slavko Vlasic",
				CardDescription = "Test Custom View",
				IconBackgroundColor = Color.SlateGray,
				IconImageSource = ImageSource.FromFile("photo.png")
			};
		}
	}
}
