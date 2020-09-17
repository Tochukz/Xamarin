using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BindingApp.Models;
using System.Collections.ObjectModel;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ObservableBookListPage : ContentPage
	{
		/* Book can be added or deleted from the Observable book collection */

		ObservableCollection<Book> bookList;

		public ObservableBookListPage()
		{
			InitializeComponent();

			bookList = new ObservableCollection<Book>
			{
				new Book { BookId = 1, Title = "Pro Express.js", Description = "Express.js from Beginner to Pro with MongoDB" },
				new Book { BookId = 2, Title = "ASP.NET 4 in Context", Description = "ASP.NET Webform 4 and MVC 3"},
				new Book { BookId = 3, Title = "Beginning C++", Description = "Begining C++"}
			};

			this.BindingContext = bookList;
		}

		private void DeleteBook(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			int bookId = (int) button.CommandParameter;
			bookList.Remove(bookList.First(book => book.BookId == bookId));
		}

		private void AddBook(object sender, EventArgs args)
		{
			string title = TitleEntry.Text;
			string description = DescriptionEditor.Text;

			Book newBook = new Book { Title = title, Description = description };
			bookList.Add(newBook);

			TitleEntry.Text = "";
			DescriptionEditor.Text = "";
		}
	}
}