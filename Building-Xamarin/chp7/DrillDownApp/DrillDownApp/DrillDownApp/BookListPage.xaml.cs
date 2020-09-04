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
	public partial class BookListPage : ContentPage
	{
		public BookListPage()
		{
			InitializeComponent();

			List<Book> books = new List<Book>
			{
				new Book {Title = "Pro MERN Stack", Author = "Vasan Subramanian", Description = "Full Stack Web App Development with Mongo, Express, React and Node"},
				new Book {Title = "Beginning C++", Author = "Ivor Horton and Peter Van Weert", Description = "From Novice to Professional, Fifth Edition "},
				new Book {Title = "Applied ASP.NET4 in Context", Author = "Adam Freeman", Description = "Understanding how ASP.NET 4 works in the real world"}
			};

			BookList.ItemsSource = books;
		}

		private async void ToBookDetails(object sender, ItemTappedEventArgs e)
		{
			Book book = (Book)e.Item;
			await Navigation.PushAsync(new BookDetailsPage(book));
			((ListView)sender).SelectedItem = null;
		}
	}
}