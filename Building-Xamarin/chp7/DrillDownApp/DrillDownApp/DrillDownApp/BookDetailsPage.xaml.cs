using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrillDownApp.Models;

namespace DrillDownApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookDetailsPage : ContentPage
	{
		public BookDetailsPage(Book book)
		{
			InitializeComponent();

			this.BindingContext = book;
		}
	}
}