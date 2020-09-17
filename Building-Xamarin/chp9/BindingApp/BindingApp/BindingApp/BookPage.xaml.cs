using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.Models;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookPage : ContentPage
	{
		Book book;

		Book book2;

		public BookPage()
		{
			InitializeComponent();

			book = new Book { Title = "Pro Express.js", Description = "Node.js with Express, and MondogDB" };

			/* This binding context is set at the Page level */
			this.BindingContext = book;

			/* Setting Binding context at the View level */
		    book2 = new Book { Price = 89.55 };
			SecondEntry.BindingContext = book2;
		}

		private async void TitleButtonClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Book Tittle", $"{book.Title}", "OK");
		}

		private async void PriceButtonClicked(object sender, EventArgs args)
		{			
			await DisplayAlert("Book Price", $"{book2.Price}", "OK");

			/* Although the Alert may display this new price when the button is clicked the second time.
			 * The price shown in the Entry view will remain the same and that is the limitation of Trivial data binding approach.
			 */
			book2.Price = 100.99;
		}
	}
}