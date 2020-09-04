using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StateApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecificationPage : ContentPage
	{
		public string HDD { set; get; }
		
		public string RAM { set; get; }

		public string Screen { set; get; }

		public SpecificationPage()
		{
			InitializeComponent();
			
			this.BindingContext = this;

			Global global = Global.GetInstance;
			HDD = global.HDD;
			RAM = global.RAM;
			Screen = global.Screen;
		}
	}
}